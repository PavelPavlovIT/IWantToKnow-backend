using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.IncorrectAnswerService.Commands.UpdateIncorrectAnswer;

public class UpdateIncorrectAnswerQuery : IRequest
{
    public required IncorrectAnswerViewModel IncorrectAnswerViewModel { get; init; }
}