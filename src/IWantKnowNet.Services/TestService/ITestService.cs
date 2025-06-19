using IWantToKnowNet.Common.ViewModels;

namespace Services.TestService;

public interface ITestService
{
    Task<NextQuestionViewModel?> GetNextQuestionsByCategoryIdAsync(string language, string userId,
        NextQuestionViewModelRequest request,
        CancellationToken cancellationToken);

    Task<StartTestViewModel?> StartTestAsync(string language, string userId, StartTestViewModelRequest request,
        CancellationToken cancellationToken);
}