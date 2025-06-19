using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CorrectAnswerService.Queries.GetCorrectAnswersByQuestionId;

public class GetCorrectAnswersByQuestionIdQuery : IRequest<IList<CorrectAnswerViewModel>?>
{
    public string Lang { get; set; }
    public required string QuestionId { get; init; }
}