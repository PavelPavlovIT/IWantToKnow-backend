using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.QuestionService.Queries.GetQuestionByQuestionId;

public class GetQuestionByQuestionIdQuery : IRequest<QuestionViewModel?>
{
    public string Lang { get; set; }
    public required string QuestionId { get; init; }
}