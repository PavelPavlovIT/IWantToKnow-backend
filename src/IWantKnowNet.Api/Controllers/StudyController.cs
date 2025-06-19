using IWantKnowNet.Api.Extensions;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.StudyService;
using Services.TestService.Queries.GetNextQuestionsByCategoryId;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class StudyController(
    UserManager<ApplicationUser> userManager,
    IStudyService studyService,
    ILogger<StudyController> logger,
    IConfiguration configuration)
    : ControllerBase
{
    [HttpGet(nameof(StartStudy))]
    public async Task<StartTestViewModel?> StartStudy(string categoryId, string typeTestId, CancellationToken cancellationToken)
    {
        var lang = userManager.GetUserAsync(User).Result?.Language ?? "en";
        var expireDateTime = userManager.GetUserAsync(User).Result?.ExpireDateTime ?? DateTime.MinValue;

        var result = await studyService.StartStudyAsync(
            lang,
            userManager.GetUserId(User)!,
            categoryId,
            typeTestId,
            CancellationToken.None);

        if (expireDateTime < DateTime.UtcNow)
        {
            result!.Expired = true;
        }

        return result;
    }

    [HttpPost(nameof(CheckAnswerStudy))]
    public async Task<bool> CheckAnswerStudy(NextQuestionViewModelRequest request, CancellationToken cancellationToken)
    {
        var lang = userManager.GetUserAsync(User).Result?.Language ?? "en";

        var result = await studyService.CheckAnswerStudyAsync(
            lang,
            userManager.GetUserId(User)!,
            request,
            CancellationToken.None);
        return result;
    }

    [HttpPost(nameof(GetNextQuestionsForStudy))]
    public async Task<NextQuestionViewModel?> GetNextQuestionsForStudy(NextQuestionViewModelRequest request, CancellationToken cancellationToken)
    {
        var lang = userManager.GetUserAsync(User).Result?.Language ?? "en";

        var result = await studyService.GetNextQuestionsForStudyAsync(
            lang,
            userManager.GetUserId(User)!,
            request,
            CancellationToken.None);
        return result;
    }

}