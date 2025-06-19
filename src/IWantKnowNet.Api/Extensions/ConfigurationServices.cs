using Services.AnalyticService;
using Services.BinanceService;
using Services.CategoryService;
using Services.CorrectAnswerService;
using Services.IncorrectAnswerService;
using Services.Payments;
using Services.QuestionService;
using Services.StudyService;
using Services.TestService;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationServices
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        return services
                .AddScoped<IAnalyticService, AnalyticService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IQuestionService, QuestionService>()
                .AddScoped<ICorrectAnswerService, CorrectAnswerService>()
                .AddScoped<IIncorrectAnswerService, IncorrectAnswerService>()
                .AddScoped<ITestService, TestService>()
                .AddScoped<IStudyService, StudyService>()
                .AddScoped<IPaymentService, PaymentService>()
                .AddScoped<IBinanceService, BinanceService>()
            ;
    }
}