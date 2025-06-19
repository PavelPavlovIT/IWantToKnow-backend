using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.TestRepository;

public interface ITestRepository
{
    Task<StartTestViewModel?> StartTestAsync(
        string lang,
        string userId,
        StartTestViewModel startTestViewModel,
        int? countQuestions,
        CancellationToken cancellationToken);

    Task<NextQuestionViewModel?> GetNextQuestionsByCategoryIdAsync(
        string lang,
        string userId,
        NextQuestionViewModelRequest request, CancellationToken cancellationToken);
}