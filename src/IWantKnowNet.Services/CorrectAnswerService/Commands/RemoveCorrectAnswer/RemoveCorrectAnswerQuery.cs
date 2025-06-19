using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CorrectAnswerService.Commands.RemoveCorrectAnswer;

public class RemoveCorrectAnswerQuery : IRequest
{
    public required CorrectAnswerViewModel CorrectAnswerViewModel { get; init; }
}