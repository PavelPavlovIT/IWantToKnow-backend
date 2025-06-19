using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.QuestionService.Commands.AddQuestion;

public class AddQuestionQuery : IRequest
{
    public required QuestionViewModel QuestionViewModel { get; init; }
}