using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.CorrectAnswer;

public interface ICorrectAnswerRepository
{
    Task<IList<CorrectAnswerViewModel>?>
        GetCorrectAnswersByQuestionIdAsync(string lang, string questionId, CancellationToken cancellationToken);

    Task<IList<CorrectAnswerViewModel>?>
        GetCorrectAnswersByCategoryIdAsync(string lang, string categoryId, CancellationToken cancellationToken);

    Task AddCorrectAnswerAsync(CorrectAnswerViewModel correctAnswerViewModel, CancellationToken cancellationToken);

    Task UpdateCorrectAnswerAsync(CorrectAnswerViewModel correctAnswerViewModel, CancellationToken cancellationToken);

    Task RemoveCorrectAnswerAsync(CorrectAnswerViewModel correctAnswerViewModel, CancellationToken cancellationToken);
}