using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.IncorrectAnswerService.Commands.AddIncorrectAnswer;
using Services.IncorrectAnswerService.Commands.RemoveIncorrectAnswer;
using Services.IncorrectAnswerService.Commands.UpdateIncorrectAnswer;
using Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByCategoryId;
using Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByQuestionId;

namespace Services.IncorrectAnswerService;

public class IncorrectAnswerService(
    ILogger<IncorrectAnswerService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), IIncorrectAnswerService
{
    public async Task<ResponseQuery<IncorrectAnswerViewModel>> GetIncorrectAnswersByQuestionIdAsync(string questionId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetIncorrectAnswersByQuestionIdAsync failed";

        try
        {
            var result = await Mediator.Send(new GetIncorrectAnswersByQuestionIdQuery
                { QuestionId = questionId }, cancellationToken);
            return new ResponseQuery<IncorrectAnswerViewModel>(true, "", result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseQuery<IncorrectAnswerViewModel>(false, errMessage);
        }
    }

    public async Task<ResponseQuery<IncorrectAnswerViewModel>?> GetIncorrectAnswersByCategoryIdAsync(string categoryId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetIncorrectAnswersByCategoryIdAsync failed";

        try
        {
            var result = await Mediator.Send(new GetIncorrectAnswersByCategoryIdQuery
                { CategoryId = categoryId }, cancellationToken);
            return new ResponseQuery<IncorrectAnswerViewModel>(true, "", result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseQuery<IncorrectAnswerViewModel>(false, errMessage);
        }
    }

    public async Task<ResponseCommand> AddIncorrectAnswerAsync(IncorrectAnswerViewModel model,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed AddIncorrectAnswerAsync fail";

        try
        {
            await Mediator.Send(new AddIncorrectAnswerQuery { IncorrectAnswerViewModel = model }, cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }

    public async Task<ResponseCommand> UpdateIncorrectAnswerAsync(IncorrectAnswerViewModel model,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed UpdateIncorrectAnswerAsync fail";

        try
        {
            await Mediator.Send(new UpdateIncorrectAnswerQuery { IncorrectAnswerViewModel = model },
                cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }

    public async Task<ResponseCommand> RemoveIncorrectAnswerAsync(IncorrectAnswerViewModel model,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed RemoveIncorrectAnswerAsync fail";

        try
        {
            await Mediator.Send(new RemoveIncorrectAnswerQuery { IncorrectAnswerViewModel = model },
                cancellationToken);
            return new ResponseCommand(true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseCommand(false, errMessage);
        }
    }
}