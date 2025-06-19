using IWantKnowNet.Data.Repositories.AnalyticRepository;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Repositories.Categories;
using IWantKnowNet.Data.Repositories.CorrectAnswer;
using IWantKnowNet.Data.Repositories.IncorrectAnswer;
using IWantKnowNet.Data.Repositories.Payment;
using IWantKnowNet.Data.Repositories.Question;
using IWantKnowNet.Data.Repositories.StudyRepository;
using IWantKnowNet.Data.Repositories.TestRepository;
using IWantKnowNet.Data.Services;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationRepositories
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        return services
            .AddScoped<IBaseRepository, BaseRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IQuestionRepository, QuestionRepository>()
            .AddScoped<ICorrectAnswerRepository, CorrectAnswerRepository>()
            .AddScoped<IIncorrectAnswerRepository, IncorrectAnswerRepository>()
            .AddScoped<ITestRepository, TestRepository>()
            .AddScoped<IAnalyticRepository, AnalyticRepository>()
            
            .AddScoped<IStudyBySpeakRepositoryEasyLevel, StudyBySpeakRepositoryEasyLevel>()
            .AddScoped<IStudyBySpeakRepositoryMediumLevel, StudyBySpeakRepositoryMediumLevel>()
            .AddScoped<IStudyBySpeakRepositoryDifficultLevel, StudyBySpeakRepositoryDifficultLevel>()
            
            .AddScoped<IStudyByReadRepository, StudyByReadRepository>()
            .AddScoped<IStudyByListenRepository, StudyByListenRepository>()
            .AddScoped<IPaymentRepository, PaymentRepository>()
            .AddScoped<IDataService, DataService>()
            ;
    }
}