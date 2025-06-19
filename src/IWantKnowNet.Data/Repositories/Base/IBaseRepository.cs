using IWantKnowNet.Data.Database;
using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.Base;

public interface IBaseRepository
{
    Task<List<CorrectAnswerViewModel>> GetCorrectAnswersAsync(
        ApplicationDbContext context,
        string testId,
        string typeTestId,
        QuestionViewModel questionViewModel,
        int countAnswers,
        int numberQuestion,
        CancellationToken cancellationToken);
    Task<List<CorrectAnswerViewModel>> GetCorrectAnswersForSpeakAsync(
        ApplicationDbContext context,
        QuestionViewModel questionViewModel,
        CancellationToken cancellationToken);
}