using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;

namespace Services.IncorrectAnswerService;

public interface IIncorrectAnswerService
{
    Task<ResponseQuery<IncorrectAnswerViewModel>> GetIncorrectAnswersByQuestionIdAsync(string questionId,
        CancellationToken cancellationToken);
    Task<ResponseQuery<IncorrectAnswerViewModel>?> GetIncorrectAnswersByCategoryIdAsync(string categoryId,
        CancellationToken cancellationToken);
    Task<ResponseCommand> AddIncorrectAnswerAsync(IncorrectAnswerViewModel model, CancellationToken cancellationToken);
    Task<ResponseCommand> UpdateIncorrectAnswerAsync(IncorrectAnswerViewModel model, CancellationToken cancellationToken);
    Task<ResponseCommand> RemoveIncorrectAnswerAsync(IncorrectAnswerViewModel model, CancellationToken cancellationToken);
}