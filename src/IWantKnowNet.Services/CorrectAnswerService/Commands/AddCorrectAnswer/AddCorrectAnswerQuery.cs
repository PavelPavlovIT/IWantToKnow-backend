using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CorrectAnswerService.Commands.AddCorrectAnswer;

public class AddCorrectAnswerQuery : IRequest
{
    public required CorrectAnswerViewModel CorrectAnswerViewModel { get; init; }
}