using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IWantKnowNet.Api.Controllers.ExtProviders;

[ApiController]
[Route("[controller]")]

public class ExtProviderController(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    ILogger<ExtProviderController> logger,
    IConfiguration configuration) : AuthGoogleController(signInManager, userManager, roleManager, logger, configuration)
{
}