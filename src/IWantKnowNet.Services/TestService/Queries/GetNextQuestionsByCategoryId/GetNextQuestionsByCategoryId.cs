using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TestService.Queries.GetNextQuestionsByCategoryId;

public class GetNextQuestionsByCategoryId : IRequest<NextQuestionViewModel?>
{
    public required string UserId { get; set; }
    public required NextQuestionViewModelRequest Request { get; set; }
    public string Lang { get; set; }
}