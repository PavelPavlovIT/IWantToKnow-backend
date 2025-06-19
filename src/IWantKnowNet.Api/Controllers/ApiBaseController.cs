using System.Security.Claims;
using IWantKnowNet.Data.Entity;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IWantKnowNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiBaseController(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
        : ControllerBase
    {
        protected readonly IConfiguration Configuration = configuration;
        protected readonly UserManager<ApplicationUser> UserManager = userManager;

        protected string Language
        {
            get
            {
                var lang = UserManager.GetUserAsync(User).Result?.Language ?? "en";
                return lang;
            }
        }

        protected DateTime ExpireDateTime
        {
            get
            {
                var expireDateTime = UserManager.GetUserAsync(User).Result?.ExpireDateTime ?? DateTime.MinValue;
                return expireDateTime;
            }
        }
        
    }
}