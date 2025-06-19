using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.AnalyticService;
using Services.TestService;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class AnalyticController(
    ILogger<AnalyticController> logger,
    UserManager<ApplicationUser> userManager,
    IAnalyticService analyticService,
    IConfiguration configuration)
    : ApiBaseController(userManager, configuration)
{
    [HttpGet]
    [Route("GetAllLastTestByUserIdBySpeaking")]
    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdBySpeakingAsync(
        CancellationToken cancellationToken)
    {
        var result = await analyticService.GetAllLastTestByUserIdBySpeakingAsync(
            userManager.GetUserId(User)!,
            CancellationToken.None);
        return result;
    }

    [HttpGet]
    [Route("GetAllLastTestByUserIdByListen")]
    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByListenAsync(
        CancellationToken cancellationToken)
    {
        var result = await analyticService.GetAllLastTestByUserIdByListenAsync(
            userManager.GetUserId(User)!,
            CancellationToken.None);
        return result;
    }

    [HttpGet]
    [Route("GetAllLastTestByUserIdByRead")]
    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByReadAsync(
        CancellationToken cancellationToken)
    {
        var result = await analyticService.GetAllLastTestByUserIdByReadAsync(
            userManager.GetUserId(User)!,
            CancellationToken.None);
        return result;
    }

    [HttpGet]
    [Route("GetResultDetailByTestId")]
    public async Task<IList<TestResultDetailsViewModel>?> GetResultDetailByTestIdAsync(
        string testId,
        CancellationToken cancellationToken)
    {
        var result = await analyticService.GetResultDetailByTestIdAsync(
            testId,
            CancellationToken.None);
        return result;
    }
}