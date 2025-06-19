using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.QuestionService.Commands.RemoveQuestion;

public class RemoveQuestionQuery : IRequest
{
    public required QuestionViewModel QuestionViewModel { get; init; }
}