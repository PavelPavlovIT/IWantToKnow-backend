using System.IdentityModel.Tokens.Jwt;
using IWantKnowNet.Data.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using IWantKnowNet.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using IWantToKnowNet.Common.Utils;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IWantKnowNet.Api.Controllers.ExtProviders
{
    [ApiController]
    [Route("[controller]")]
    public class AuthGoogleController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<AuthGoogleController> logger,
        IConfiguration configuration)
        //: ApiBaseController(userManager, configuration)
        : ControllerBase

    {
        protected readonly UserManager<ApplicationUser> UserManager = userManager;
        protected readonly RoleManager<IdentityRole> RoleManager = roleManager;
        protected readonly SignInManager<ApplicationUser> SignInManager = signInManager;

        [HttpGet(nameof(SignInWithGoogle))]
        public IActionResult SignInWithGoogle(string lang)
        {
            var authenticationProperties =
                SignInManager.ConfigureExternalAuthenticationProperties("Google",
                    Url.Action(nameof(HandleExternalLogin), new { lang = lang }));
            return Challenge(authenticationProperties, "Google");
        }

        [HttpGet(nameof(HandleExternalLogin))]
        public async Task<IActionResult> HandleExternalLogin(string lang = "en")
        {
            var token = String.Empty;
            var info = await SignInManager.GetExternalLoginInfoAsync();
            if (info?.LoginProvider == null) return Redirect(configuration["FrontPublicApi"]!);
            var resultLogin =
                await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                    isPersistent: false);

            if (!resultLogin.Succeeded) //user does not exist yet
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var newUser = new ApplicationUser()
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    Language = lang,
                    ExpireDateTime = DateTime.UtcNow.AddDays(double.Parse(configuration["FreeDays"]!))
                };
                var createResult = await UserManager.CreateAsync(newUser);
                if (!createResult.Succeeded)
                    throw new Exception(createResult.Errors.Select(e => e.Description)
                        .Aggregate((errors, error) => $"{errors}, {error}"));

                await UserManager.AddLoginAsync(newUser, info);
                var newUserClaims = info.Principal.Claims.Append(new Claim("userId", newUser.Id));
                await UserManager.AddClaimsAsync(newUser, newUserClaims);

                await SignInManager.SignInAsync(newUser, isPersistent: false);
                if (await RoleManager.RoleExistsAsync(nameof(User)))
                    await UserManager.AddToRoleAsync(newUser, nameof(User));
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            }
            //return Ok();
            return Redirect(configuration["FrontPublicApi"]!);
        }

        private string GenerateToken(string? userName)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Name, userName!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWTSecret"]!));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration["JWTValidIssuer"],
                Audience = configuration["JWTValidAudience"],
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}