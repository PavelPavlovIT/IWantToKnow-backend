using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.QuestionService.Commands.UpdateQuestion;

public class UpdateQuestionQuery : IRequest
{
    public required QuestionViewModel QuestionViewModel { get; init; }
}