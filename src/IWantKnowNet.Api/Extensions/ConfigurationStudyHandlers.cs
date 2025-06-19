using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.StudyService.Commands.StartStudy;
using Services.StudyService.Queries.CheckAnswerStudy;
using Services.StudyService.Queries.GetNextQuestionsForStudy;
using Services.TestService.Commands.StartTest;
using Services.TestService.Queries.GetNextQuestionsByCategoryId;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationStudyHandlers
{
    public static IServiceCollection AddStudyHandlers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IRequestHandler<StartStudyCommand,
                    StartTestViewModel?>,
                StartStudyHandler>()
            .AddTransient<IRequestHandler<GetNextQuestionsForStudyQuery, NextQuestionViewModel?>,
                GetNextQuestionsForStudyHandler>()

            .AddTransient<IRequestHandler<CheckAnswerStudyQuery,
                    bool>,
                CheckAnswerStudyHandler>()

            .AddTransient<IRequestHandler<StartTestCommand,
                    StartTestViewModel?>,
                StartTestHandler>()
            .AddTransient<IRequestHandler<GetNextQuestionsByCategoryId,
                    NextQuestionViewModel?>,
                GetNextQuestionsByCategoryIdHandler>()
            ;
    }
}