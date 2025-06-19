using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CorrectAnswerService.Queries.GetCorrectAnswersByCategoryId;

public class GetCorrectAnswersByCategoryIdQuery : IRequest<IList<CorrectAnswerViewModel>?>
{
    public string Lang { get; set; }
    public required string CategoryId { get; init; }
}