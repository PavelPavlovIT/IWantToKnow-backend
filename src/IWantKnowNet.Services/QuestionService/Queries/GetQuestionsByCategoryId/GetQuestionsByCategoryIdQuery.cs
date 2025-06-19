using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.QuestionService.Queries.GetQuestionsByCategoryId;

public class GetQuestionsByCategoryIdQuery : IRequest<IList<QuestionViewModel>?>
{
    public string Lang { get; set; }
    public string? CategoryId { get; init; }
}