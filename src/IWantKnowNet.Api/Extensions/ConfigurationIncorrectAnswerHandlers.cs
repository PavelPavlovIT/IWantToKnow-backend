using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.IncorrectAnswerService.Commands.AddIncorrectAnswer;
using Services.IncorrectAnswerService.Commands.RemoveIncorrectAnswer;
using Services.IncorrectAnswerService.Commands.UpdateIncorrectAnswer;
using Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByQuestionId;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationIncorrectAnswerHandlers
{
    public static IServiceCollection AddIncorrectAnswerHandlers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IRequestHandler<GetIncorrectAnswersByQuestionIdQuery, IList<IncorrectAnswerViewModel>?>,
                GetIncorrectAnswersByQuestionIdHandler>()
            .AddTransient<IRequestHandler<AddIncorrectAnswerQuery>, AddIncorrectAnswerHandler>()
            .AddTransient<IRequestHandler<UpdateIncorrectAnswerQuery>, UpdateIncorrectAnswerHandler>()
            .AddTransient<IRequestHandler<RemoveIncorrectAnswerQuery>, RemoveIncorrectAnswerHandler>();
    }
}