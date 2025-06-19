using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.StudyRepository;

public interface IStudyBySpeakRepositoryMediumLevel
{
    public Task<StartTestViewModel?> StartStudyAsync(string lang, string userId, string categoryId, CancellationToken cancellationToken);
    public Task<bool> CheckAnswerStudyAsync(string lang, string userId, NextQuestionViewModelRequest request, CancellationToken cancellationToken);
    
    public Task<NextQuestionViewModel?> GetNextQuestionsForStudyAsync(
        string lang,
        string userId,
        NextQuestionViewModelRequest request, CancellationToken cancellationToken);

}