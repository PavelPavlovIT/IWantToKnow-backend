using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.IncorrectAnswerService.Commands.RemoveIncorrectAnswer;

public class RemoveIncorrectAnswerQuery : IRequest
{
    public required IncorrectAnswerViewModel IncorrectAnswerViewModel { get; init; }
}