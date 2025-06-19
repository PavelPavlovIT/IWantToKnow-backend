using IWantToKnowNet.Common.ViewModels;

namespace Services.AnalyticService;

public interface IAnalyticService
{
    Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByListenAsync(
        string userId, 
        CancellationToken cancellationToken);
    Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByReadAsync(
        string userId,
        CancellationToken cancellationToken);

    Task<IList<TestResultDetailsViewModel>?> GetResultDetailByTestIdAsync(string testId,
        CancellationToken cancellationToken);

    Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdBySpeakingAsync(string userId, CancellationToken cancellationToken);
}