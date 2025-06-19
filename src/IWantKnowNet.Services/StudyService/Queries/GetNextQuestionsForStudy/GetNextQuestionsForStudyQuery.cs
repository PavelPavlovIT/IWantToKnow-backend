using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.StudyService.Queries.GetNextQuestionsForStudy;

public class GetNextQuestionsForStudyQuery : IRequest<NextQuestionViewModel?>
{
    public string Lang { get; set; }
    public required string UserId { get; set; }
    public required NextQuestionViewModelRequest Request { get; set; }
}