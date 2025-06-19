using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.IncorrectAnswer;

public interface IIncorrectAnswerRepository
{
    Task<IList<IncorrectAnswerViewModel>?>
        GetIncorrectAnswersByQuestionIdAsync(string questionId, CancellationToken cancellationToken);

    Task<IList<IncorrectAnswerViewModel>?>
        GetIncorrectAnswersByCategoryIdAsync(string categoryId, CancellationToken cancellationToken);

    Task AddIncorrectAnswerAsync(IncorrectAnswerViewModel incorrectAnswerViewModel, CancellationToken cancellationToken);

    Task UpdateIncorrectAnswerAsync(IncorrectAnswerViewModel incorrectAnswerViewModel, CancellationToken cancellationToken);

    Task RemoveIncorrectAnswerAsync(IncorrectAnswerViewModel incorrectAnswerViewModel, CancellationToken cancellationToken);
}