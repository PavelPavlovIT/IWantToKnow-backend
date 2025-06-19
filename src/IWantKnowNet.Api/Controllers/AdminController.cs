using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IWantKnowNet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController(
        UserManager<ApplicationUser> userManager,
        ILogger<AdminController> logger,
        IConfiguration configuration)
        //: ApiBaseController(userManager, logger, configuration)
        : ControllerBase
    {

        [HttpGet(nameof(GetVersion))]
        public async Task<string> GetVersion()
        {
            try
            {
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return await Task.FromResult($"Version = {version}");
            }
            catch (Exception ex)
            {
                var message = $"Error message: {ex.Message} {ex.InnerException?.Message}";
                //Logger.LogError(message);
                return await Task.FromResult(message);
            }
        }
    }
}