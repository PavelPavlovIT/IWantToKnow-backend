using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByQuestionId;

public class GetIncorrectAnswersByQuestionIdQuery : IRequest<IList<IncorrectAnswerViewModel>?>
{
    public required string QuestionId { get; init; }
}