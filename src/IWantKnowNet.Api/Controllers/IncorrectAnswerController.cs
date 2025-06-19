using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.IncorrectAnswerService;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class IncorrectAnswerController(
    ILogger<IncorrectAnswerController> logger,
    UserManager<ApplicationUser> userManager,
    IIncorrectAnswerService incorrectAnswerService,
    IConfiguration configuration)
    : ApiBaseController(userManager, configuration)
{
    [HttpGet]
    [Route("GetIncorrectAnswersByQuestionId")]
    public async Task<ResponseQuery<IncorrectAnswerViewModel>?> GetIncorrectAnswersByQuestionId(string questionId,
        CancellationToken cancellationToken)
    {
        return await incorrectAnswerService.GetIncorrectAnswersByQuestionIdAsync(questionId, CancellationToken.None);
    }

    [HttpGet]
    [Route("GetIncorrectAnswersByCategoryId")]
    public async Task<ResponseQuery<IncorrectAnswerViewModel>?> GetIncorrectAnswersByCategoryId(string categoryId,
        CancellationToken cancellationToken)
    {
        return await incorrectAnswerService.GetIncorrectAnswersByCategoryIdAsync(categoryId, CancellationToken.None);
    }

    [HttpPost]
    [Route("AddIncorrectAnswer")]
    public async Task AddIncorrectAnswer(IncorrectAnswerViewModel model, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        model = model with { CreaterId = userId, ApproverId = userId };
        await incorrectAnswerService.AddIncorrectAnswerAsync(model, CancellationToken.None);
    }

    [HttpPost]
    [Route("UpdateIncorrectAnswer")]
    public async Task UpdateIncorrectAnswer(IncorrectAnswerViewModel model, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        model = model with { CreaterId = userId, ApproverId = userId };
        await incorrectAnswerService.UpdateIncorrectAnswerAsync(model, CancellationToken.None);
    }

    [HttpPost]
    [Route("RemoveIncorrectAnswer")]
    public async Task RemoveIncorrectAnswer(IncorrectAnswerViewModel model, CancellationToken cancellationToken)
    {
        await incorrectAnswerService.RemoveIncorrectAnswerAsync(model, CancellationToken.None);
    }
}