using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IWantKnowNet.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using IWantKnowNet.Api.Controllers.ExtProviders;
using IWantKnowNet.Api.Extensions;
using IWantToKnowNet.Common.ViewModels;
using IWantToKnowNet.Common.Utils;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Services.Emails;
using Microsoft.AspNetCore.Http.Extensions;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Org.BouncyCastle.Ocsp;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Amazon.Runtime;

namespace IWantKnowNet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AccountController(
        IEmailSenderGrid emailSender,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<AccountController> logger,
        IConfiguration configuration)
        : ExtProviderController(signInManager, userManager, roleManager, logger, configuration)
    {
        [HttpGet(nameof(Logout))]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Redirect($"{configuration["FrontPublicApi"]}/products/categories");
        }

        [HttpGet(nameof(GetLanguage))]
        [Authorize]
        public ActionResult<string> GetLanguage()
        {
            return UserManager.GetUserAsync(User).Result?.Language ?? "en"; ;
        }

        [HttpGet(nameof(GetExpireDateTime))]
        [Authorize]
        public ActionResult<DateTime> GetExpireDateTime()
        {
            return UserManager.GetUserAsync(User).Result?.ExpireDateTime ?? DateTime.MinValue;
        }

        [HttpGet(nameof(SetLanguage))]
        [Authorize]
        public async Task<ActionResult> SetLanguage(string language)
        {
            var user = await UserManager.GetUserAsync(User);
            user!.Language = language;
            await UserManager.UpdateAsync(user);
            return Ok();
        }


        [HttpGet(nameof(GetAccount))]
        [Authorize]
        public ActionResult<UserInfoViewModel> GetAccount()
        {
            var user = UserManager.GetUserAsync(User).Result;
            return Ok(new UserInfoViewModel
            {
                Id = user!.Id,
                Email = user.Email!,
                Language = user.Language,
                ExpireDateTime = user.ExpireDateTime!.Value
            });
        }

        [HttpGet(nameof(ConfirmEmail))]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                logger.LogError($"ConfirmEmail: userId = `{userId}` code=`{code}`");
                return BadRequest($"Error confirming email. userId = `{userId}` code=`{code}`");
            }
            var user = await UserManager.FindByIdAsync(userId);
            var codeDecodedBytes = WebEncoders.Base64UrlDecode(code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);
            var result = await UserManager.ConfirmEmailAsync(user!, codeDecoded);
            if (result.Succeeded)
            {
                return Ok("Confirmed email");
            }
            return BadRequest("Error");
        }

        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            var returnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = model.Email, 
                    Email = model.Email, 
                    Language = model.Language,
                    ExpireDateTime = DateTime.UtcNow.AddDays(double.Parse(configuration["FreeDays"]!))
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    //var callbackUrl = $"{configuration["FrontPublicApi"]!}/confirm-email/userid={user.Id}/code={code}";
                    var callbackUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/Account/ConfirmEmail?userid={user.Id}&code={code}";
                    await emailSender.SendEmailAsync(model.Email, "Confirm your account",
                        "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    return Ok("RegistrationConfirmation");
                }
                //AddErrors(result);
                return BadRequest(result);
            }

            return Ok(model);
        }

        [HttpPost(nameof(ResetPassword))]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (model.UserId == null || model.Token == null)
            {
                logger.LogError($"ResetPassword: userId = `{model.UserId}` code=`{model.Token}`");
                return BadRequest($"Error reseting password. userId = `{model.UserId} ` code=` {model.Token}`");
            }
            var user = await UserManager.FindByIdAsync(model.UserId);
            var tokenDecodedBytes = WebEncoders.Base64UrlDecode(model.Token);
            var tokenDecoded = Encoding.UTF8.GetString(tokenDecodedBytes);
            var result = await UserManager.ResetPasswordAsync(user!, tokenDecoded, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password reseted");
            }
            logger.LogError($"ResetPassword: userId = `{model.UserId}` code=`{model.Token}`");
            AddErrors(result);
            return BadRequest(result.Errors);

        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                if (error == result.Errors.First())
                    continue;
                else ModelState.AddModelError("", $"{error.Code}-{error.Description}");
            }
        }

        [HttpPost(nameof(ForgotPassword))]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return BadRequest("User not found or email not confirmed");
                }

                var code = await UserManager.GeneratePasswordResetTokenAsync(user);
                var token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = $"{configuration["FrontPublicApi"]!}/account/reset/{user.Id}/{token}";
                //    var callbackUrl = Url.Action("ResetPassword", "Account",
                //new { UserId = user.Id, code = code }, protocol: Request.Scheme);
                await emailSender.SendEmailAsync(model.Email, "Reset Password",
            "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                return Ok("Check your email");
            }

            // If we got this far, something failed, redisplay form
            return BadRequest("Some unknown shit happened");
        }
    }
}