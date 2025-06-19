using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.CorrectAnswerService;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class CorrectAnswerController(
    ILogger<CorrectAnswerController> logger,
    UserManager<ApplicationUser> userManager,
    ICorrectAnswerService correctAnswerService,
    IConfiguration configuration)
    : ApiBaseController(userManager, configuration)
{
    [HttpGet]
    [Route("GetCorrectAnswersByQuestionId")]
    public async Task<ResponseQuery<CorrectAnswerViewModel>> GetCorrectAnswersByQuestionId(string questionId,
        CancellationToken cancellationToken)
    {
        return await correctAnswerService.GetCorrectAnswersByQuestionIdAsync(Language, questionId,
            CancellationToken.None);
    }

    [HttpGet]
    [Route("GetCorrectAnswersByCategoryId")]
    public async Task<ResponseQuery<CorrectAnswerViewModel>> GetCorrectAnswersByCategoryId(string categoryId,
        CancellationToken cancellationToken)
    {
        return await correctAnswerService.GetCorrectAnswersByCategoryIdAsync(Language, categoryId,
            CancellationToken.None);
    }

    [HttpPost]
    [Route("AddCorrectAnswer")]
    public async Task AddCorrectAnswer(CorrectAnswerViewModel model, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        model.CreaterId = userId;
        model.ApproverId = userId;
        await correctAnswerService.AddCorrectAnswerAsync(model, CancellationToken.None);
    }

    [HttpPost]
    [Route("UpdateCorrectAnswer")]
    public async Task UpdateCorrectAnswer(CorrectAnswerViewModel model, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        model.CreaterId = userId;
        model.ApproverId = userId;
        await correctAnswerService.UpdateCorrectAnswerAsync(model, CancellationToken.None);
    }

    [HttpPost]
    [Route("RemoveCorrectAnswer")]
    public async Task RemoveCorrectAnswer(CorrectAnswerViewModel model, CancellationToken cancellationToken)
    {
        await correctAnswerService.RemoveCorrectAnswerAsync(model, CancellationToken.None);
    }
}