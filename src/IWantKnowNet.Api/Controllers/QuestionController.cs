using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.QuestionService;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class QuestionController(
    ILogger<QuestionController> logger,
    UserManager<ApplicationUser> userManager,
    IQuestionService questionService,
    IConfiguration configuration)
    : ApiBaseController(userManager, configuration)
{
    [HttpGet]
    [Route("GetQuestionsByCategoryId")]
    public async Task<ResponseQuery<QuestionViewModel>?> GetQuestionsByCategoryId(string? categoryId,
        CancellationToken cancellationToken)
    {
        return await questionService.GetQuestionsByCategoryIdAsync(Language, categoryId, CancellationToken.None);
    }

    [HttpGet]
    [Route("GetQuestionByQuestionId")]
    public async Task<QuestionViewModel?> GetQuestionByQuestionId(string questionId,
        CancellationToken cancellationToken)
    {
        return await questionService.GetQuestionByQuestionIdAsync(Language, questionId, CancellationToken.None);
    }

    [HttpPost]
    [Route("AddQuestion")]
    public async Task AddProduct(QuestionViewModel model, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        model.CreaterId = userId;
        model.ApproverId = userId;
        await questionService.AddQuestionAsync(model, CancellationToken.None);
    }

    [HttpPost]
    [Route("UpdateQuestion")]
    public async Task<ResponseCommand> UpdateProduct(QuestionViewModel model, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        model.CreaterId = userId;
        model.ApproverId = userId;
        var result = await questionService.UpdateQuestionAsync(model, CancellationToken.None);
        return result;
    }

    [HttpPost]
    [Route("RemoveQuestion")]
    public async Task RemoveProduct(QuestionViewModel model, CancellationToken cancellationToken)
    {
        await questionService.RemoveQuestionAsync(model, CancellationToken.None);
    }
}