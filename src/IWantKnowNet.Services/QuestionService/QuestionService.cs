using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.QuestionService.Commands.AddQuestion;
using Services.QuestionService.Commands.RemoveQuestion;
using Services.QuestionService.Commands.UpdateQuestion;
using Services.QuestionService.Queries.GetQuestionByQuestionId;
using Services.QuestionService.Queries.GetQuestionsByCategoryId;

namespace Services.QuestionService;

public class QuestionService(
    ILogger<QuestionService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), IQuestionService
{
    public async Task<ResponseQuery<QuestionViewModel>?> GetQuestionsByCategoryIdAsync(
        string lang, string? categoryId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetQuestionsByCategoryIdAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetQuestionsByCategoryIdQuery { Lang = lang, CategoryId = categoryId },
                cancellationToken);
            return new ResponseQuery<QuestionViewModel>(true, "", result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseQuery<QuestionViewModel>(false, errMessage);
        }
    }

    public async Task<QuestionViewModel?> GetQuestionByQuestionIdAsync(
        string lang, string questionId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetQuestionByQuestionIdAsync failed";

        try
        {
            return await Mediator.Send(new GetQuestionByQuestionIdQuery { Lang = lang, QuestionId = questionId },
                cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<ResponseCommand> AddQuestionAsync(
        QuestionViewModel model, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed AddQuestionAsync fail";

        try
        {
            await Mediator.Send(new AddQuestionQuery { QuestionViewModel = model }, cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }

    public async Task<ResponseCommand> UpdateQuestionAsync(
        QuestionViewModel model, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed UpdateQuestionAsync fail";

        try
        {
            await Mediator.Send(new UpdateQuestionQuery {  QuestionViewModel = model }, cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{Message}", errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }

    public async Task<ResponseCommand> RemoveQuestionAsync(QuestionViewModel model, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed RemoveQuestionAsync fail";

        try
        {
            await Mediator.Send(new RemoveQuestionQuery { QuestionViewModel = model }, cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{Message}", errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }
}