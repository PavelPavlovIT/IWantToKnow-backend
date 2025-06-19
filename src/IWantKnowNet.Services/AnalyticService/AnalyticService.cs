using AutoMapper;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdByListen;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdByRead;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdBySpeaking;
using Services.AnalyticService.Queries.GetResultDetailByTestId;

namespace Services.AnalyticService;

public class AnalyticService(
    IMapper mapper,
    ILogger<AnalyticService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), IAnalyticService
{
    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdBySpeakingAsync(string userId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetAllLastTestByUserIdBySpeaking failed";

        try
        {
            var result = await Mediator.Send(
                new GetAllLastTestByUserIdBySpeakingQuery()
                {
                    UserId = userId,
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByListenAsync(string userId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetAllLastTestByUserIdByListenAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetAllLastTestByUserIdByListenQuery
                {
                    UserId = userId,
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByReadAsync(string userId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetAllLastTestByUserIdByReadAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetAllLastTestByUserIdByReadQuery
                {
                    UserId = userId,
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<IList<TestResultDetailsViewModel>?> GetResultDetailByTestIdAsync(
        string testId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetResultDetailByTestId failed";
        
        try
        {
            var result = await Mediator.Send(
                new GetResultDetailByTestId
                {
                    TestId = testId,
                },
                cancellationToken);
            
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }
}