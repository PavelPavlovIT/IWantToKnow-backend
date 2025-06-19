using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.AnalyticRepository;

public interface IAnalyticRepository
{
    Task<Dictionary<string, List<TestResultViewModel>>> GetLastResultsTestByCategoryIdForUserByRead(string userId, string? categoryId, CancellationToken cancellationToken);
    Task<Dictionary<string, List<TestResultViewModel>>> GetLastResultsTestByCategoryIdForUserByListen(string userId, string? categoryId, CancellationToken cancellationToken);
    Task<Dictionary<string, List<TestResultViewModel>>> GetLastResultsTestByCategoryIdForUserBySpeaking(string userId, string? categoryId, CancellationToken cancellationToken);
    Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByReadAsync(
        string userId, 
        CancellationToken cancellationToken);
    Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByListenAsync(
        string userId,
        CancellationToken cancellationToken);
    Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdBySpeakingAsync(
        string userId,
        CancellationToken cancellationToken);

    Task<IList<TestResultDetailsViewModel>> GetResultDetailByTestIdAsync(string lang, string testId,
        CancellationToken cancellationToken);


}