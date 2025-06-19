using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.TestService;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController(
    UserManager<ApplicationUser> userManager,
    ITestService testService,
    ILogger<TestController> logger,
    IConfiguration configuration)
    : ControllerBase
{
    [HttpPost(nameof(GetNextQuestionsByCategoryId))]
    public async Task<NextQuestionViewModel?> GetNextQuestionsByCategoryId(
        NextQuestionViewModelRequest request,
        CancellationToken cancellationToken)
    {
        var lang = userManager.GetUserAsync(User).Result?.Language ?? "en";
        var expireDateTime = userManager.GetUserAsync(User).Result?.ExpireDateTime ?? DateTime.MinValue;

        var result = await testService.GetNextQuestionsByCategoryIdAsync(
            lang, 
            userManager.GetUserId(User)!,
            request,
            CancellationToken.None);
        return result;
    }

    [HttpPost(nameof(StartTest))]
    public async Task<StartTestViewModel?> StartTest(
        StartTestViewModelRequest request,
        CancellationToken cancellationToken)
    {
        var lang = userManager.GetUserAsync(User).Result?.Language ?? "en";
        var expireDateTime = userManager.GetUserAsync(User).Result?.ExpireDateTime ?? DateTime.MinValue;

        var result = await testService.StartTestAsync(

            lang,
            userManager.GetUserId(User)!,
            request,
            CancellationToken.None);

        if (expireDateTime < DateTime.UtcNow)
        {
            result!.Expired = true;
        }

        return result;
    }
}