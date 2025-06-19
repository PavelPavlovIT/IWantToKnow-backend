using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.AnalyticService.Queries.GetAllLastTestByUserId;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdByListen;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdByRead;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdBySpeaking;
using Services.AnalyticService.Queries.GetResultDetailByTestId;
using Services.TestService.Commands.StartTest;
using Services.TestService.Queries.GetNextQuestionsByCategoryId;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationAnalyticHandlers
{
    public static IServiceCollection AddAnalyticHandlers(
        this IServiceCollection services)
    {
        return services
                .AddTransient<IRequestHandler<GetAllLastTestByUserIdBySpeakingQuery,
                        List<GetAllLastTestByUserIdViewModel>?>,
                    GetAllLastTestByUserIdBySpeakingHandler>()
                .AddTransient<IRequestHandler<GetAllLastTestByUserIdByListenQuery,
                        List<GetAllLastTestByUserIdViewModel>?>,
                    GetAllLastTestByUserIdByListenHandler>()
                .AddTransient<IRequestHandler<GetAllLastTestByUserIdByReadQuery,
                        List<GetAllLastTestByUserIdViewModel>?>,
                    GetAllLastTestByUserIdByReadHandler>()
                .AddTransient<IRequestHandler<GetResultDetailByTestId,
                        IList<TestResultDetailsViewModel>?>,
                    GetResultDetailByTestIdHandler>()
            ;
    }
}