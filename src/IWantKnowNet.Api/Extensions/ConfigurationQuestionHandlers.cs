using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.QuestionService.Commands.AddQuestion;
using Services.QuestionService.Commands.RemoveQuestion;
using Services.QuestionService.Commands.UpdateQuestion;
using Services.QuestionService.Queries.GetQuestionByQuestionId;
using Services.QuestionService.Queries.GetQuestionsByCategoryId;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationQuestionHandlers
{
    public static IServiceCollection AddQuestionHandlers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IRequestHandler<GetQuestionByQuestionIdQuery, QuestionViewModel?>,
                GetQuestionByQuestionIdHandler>()
            .AddTransient<IRequestHandler<GetQuestionsByCategoryIdQuery, IList<QuestionViewModel>?>,
                GetQuestionsByCategoryIdHandler>()
            .AddTransient<IRequestHandler<AddQuestionQuery>, AddQuestionHandler>()
            .AddTransient<IRequestHandler<UpdateQuestionQuery>, UpdateQuestionHandler>()
            .AddTransient<IRequestHandler<RemoveQuestionQuery>, RemoveQuestionHandler>();
    }
}