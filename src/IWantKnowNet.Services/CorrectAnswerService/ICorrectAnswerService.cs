using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;

namespace Services.CorrectAnswerService;

public interface ICorrectAnswerService
{
    Task<ResponseQuery<CorrectAnswerViewModel>> GetCorrectAnswersByQuestionIdAsync(
        string lang, string questionId,
        CancellationToken cancellationToken);
    Task<ResponseQuery<CorrectAnswerViewModel>> GetCorrectAnswersByCategoryIdAsync(
        string lang, string categoryId,
        CancellationToken cancellationToken);
    Task<ResponseCommand> AddCorrectAnswerAsync(CorrectAnswerViewModel model, CancellationToken cancellationToken);
    Task<ResponseCommand> UpdateCorrectAnswerAsync(CorrectAnswerViewModel model, CancellationToken cancellationToken);
    Task<ResponseCommand> RemoveCorrectAnswerAsync(CorrectAnswerViewModel model, CancellationToken cancellationToken);
}