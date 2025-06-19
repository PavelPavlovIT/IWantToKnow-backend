using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.IncorrectAnswerService.Commands.AddIncorrectAnswer;

public class AddIncorrectAnswerQuery : IRequest
{
    public required IncorrectAnswerViewModel IncorrectAnswerViewModel { get; init; }
}