using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CorrectAnswerService.Commands.UpdateCorrectAnswer;

public class UpdateCorrectAnswerQuery : IRequest
{
    public required CorrectAnswerViewModel CorrectAnswerViewModel { get; init; }
}