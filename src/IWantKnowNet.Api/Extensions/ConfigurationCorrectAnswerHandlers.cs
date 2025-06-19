using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.CorrectAnswerService.Commands.AddCorrectAnswer;
using Services.CorrectAnswerService.Commands.RemoveCorrectAnswer;
using Services.CorrectAnswerService.Commands.UpdateCorrectAnswer;
using Services.CorrectAnswerService.Queries.GetCorrectAnswersByCategoryId;
using Services.CorrectAnswerService.Queries.GetCorrectAnswersByQuestionId;
using Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByQuestionId;
using Services.QuestionService.Commands.AddQuestion;
using Services.QuestionService.Commands.RemoveQuestion;
using Services.QuestionService.Commands.UpdateQuestion;
using Services.QuestionService.Queries.GetQuestionByQuestionId;
using Services.QuestionService.Queries.GetQuestionsByCategoryId;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationCorrectAnswerHandlers
{
    public static IServiceCollection AddCorrectAnswerHandlers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IRequestHandler<GetCorrectAnswersByQuestionIdQuery, IList<CorrectAnswerViewModel>?>,
                GetCorrectAnswersByQuestionIdHandler>()
            .AddTransient<IRequestHandler<GetCorrectAnswersByCategoryIdQuery, IList<CorrectAnswerViewModel>?>,
                GetCorrectAnswersByCategoryIdHandler>()
            .AddTransient<IRequestHandler<AddCorrectAnswerQuery>, AddCorrectAnswerHandler>()
            .AddTransient<IRequestHandler<UpdateCorrectAnswerQuery>, UpdateCorrectAnswerHandler>()
            .AddTransient<IRequestHandler<RemoveCorrectAnswerQuery>, RemoveCorrectAnswerHandler>();
    }
}