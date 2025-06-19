using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByCategoryId;

public class GetIncorrectAnswersByCategoryIdQuery : IRequest<IList<IncorrectAnswerViewModel>?>
{
    public required string CategoryId { get; init; }
}