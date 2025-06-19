using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.CorrectAnswerService.Commands.AddCorrectAnswer;
using Services.CorrectAnswerService.Commands.RemoveCorrectAnswer;
using Services.CorrectAnswerService.Commands.UpdateCorrectAnswer;
using Services.CorrectAnswerService.Queries.GetCorrectAnswersByCategoryId;
using Services.CorrectAnswerService.Queries.GetCorrectAnswersByQuestionId;

namespace Services.CorrectAnswerService;

public class CorrectAnswerService(
    ILogger<CorrectAnswerService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), ICorrectAnswerService
{
    public async Task<ResponseQuery<CorrectAnswerViewModel>> GetCorrectAnswersByQuestionIdAsync(
        string lang, string questionId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetCorrectAnswersByQuestionIdAsync failed";
        
        try
        {
            var result = await Mediator.Send(
                new GetCorrectAnswersByQuestionIdQuery { Lang = lang, QuestionId = questionId },
                cancellationToken); 
            return new ResponseQuery<CorrectAnswerViewModel>(true, "", result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseQuery<CorrectAnswerViewModel>(false, errMessage);
        }
    }

    public async Task<ResponseQuery<CorrectAnswerViewModel>> GetCorrectAnswersByCategoryIdAsync(
        string lang, string categoryId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetCorrectAnswersByCategoryIdAsync failed";
        
        try
        {
            var result = await Mediator.Send(
                new GetCorrectAnswersByCategoryIdQuery { Lang = lang, CategoryId = categoryId },
                cancellationToken); 
            return new ResponseQuery<CorrectAnswerViewModel>(true, "", result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseQuery<CorrectAnswerViewModel>(false, errMessage);
        }
    }

    public async Task<ResponseCommand> AddCorrectAnswerAsync(
        CorrectAnswerViewModel model,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed AddCorrectAnswerAsync fail";
        
        try
        {
            await Mediator.Send(new AddCorrectAnswerQuery { CorrectAnswerViewModel = model }, cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }

    public async Task<ResponseCommand> UpdateCorrectAnswerAsync(
        CorrectAnswerViewModel model,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed UpdateCorrectAnswerAsync fail";
        
        try
        {
            await Mediator.Send(new UpdateCorrectAnswerQuery { CorrectAnswerViewModel = model }, cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }

    public async Task<ResponseCommand> RemoveCorrectAnswerAsync(CorrectAnswerViewModel model,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed RemoveCorrectAnswerAsync fail";
        
        try
        {
            await Mediator.Send(new RemoveCorrectAnswerQuery { CorrectAnswerViewModel = model }, cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }
}