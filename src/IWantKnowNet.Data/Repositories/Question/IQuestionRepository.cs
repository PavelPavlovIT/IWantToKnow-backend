using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.Question;

public interface IQuestionRepository
{
    Task UpdateExpiredSignedUrlS3InQuestionAsync(string questionId, string signedUrlS3, DateTime expiredSignedUrlS3, CancellationToken cancellationToken);

    Task<IList<QuestionViewModel>?>
        GetQuestionsByCategoryIdAsync(string lang, string? categoryId, CancellationToken cancellationToken);

    Task<QuestionViewModel?>
        GetQuestionsByQuestionIdAsync(string lang, string questionId, CancellationToken cancellationToken);

    Task AddQuestionAsync(QuestionViewModel questionViewModel, CancellationToken cancellationToken);

    Task UpdateQuestionAsync(QuestionViewModel questionViewModel, CancellationToken cancellationToken);

    Task RemoveQuestionAsync(QuestionViewModel questionViewModel, CancellationToken cancellationToken);
}