using IWantToKnowNet.Common.ViewModels;

namespace Services.StudyService;

public interface IStudyService
{
    Task<StartTestViewModel?> StartStudyAsync(string language, string userId, string categoryId, string typeTestId, CancellationToken none);
    Task<bool> CheckAnswerStudyAsync(string language, string userId, NextQuestionViewModelRequest request, CancellationToken none);
    
    Task<NextQuestionViewModel?> GetNextQuestionsForStudyAsync(string language, string userId, NextQuestionViewModelRequest request, CancellationToken none);
}