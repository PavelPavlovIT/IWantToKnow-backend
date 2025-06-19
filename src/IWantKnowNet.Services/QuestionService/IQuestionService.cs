using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;

namespace Services.QuestionService;

public interface IQuestionService
{
    Task<ResponseQuery<QuestionViewModel>?> GetQuestionsByCategoryIdAsync(
        string lang, string? categoryId,
        CancellationToken cancellationToken);

    Task<QuestionViewModel?> GetQuestionByQuestionIdAsync(
        string lang, string questionId, CancellationToken cancellationToken);

    Task<ResponseCommand> AddQuestionAsync(
        QuestionViewModel model, CancellationToken cancellationToken);
    Task<ResponseCommand> UpdateQuestionAsync(
        QuestionViewModel model, CancellationToken cancellationToken);
    Task<ResponseCommand> RemoveQuestionAsync(
        QuestionViewModel model, CancellationToken cancellationToken);
}