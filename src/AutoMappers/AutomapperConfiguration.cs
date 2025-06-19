using AutoMappers.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMappers;

public static class AutomapperConfiguration
{
    public static IServiceCollection AddAutomapperProfiles(
        this IServiceCollection services)
    {
        return services
            .AddAutoMapper(typeof(ToQuestionViewModel))
            .AddAutoMapper(typeof(ToQuestion))
            .AddAutoMapper(typeof(ToCorrectAnswerViewModel))
            .AddAutoMapper(typeof(ToCorrectAnswer))
            // .AddAutoMapper(typeof(ToRandomQuestionViewModel))
        ;
    }
}