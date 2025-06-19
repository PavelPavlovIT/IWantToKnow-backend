using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.StudyService.Queries.CheckAnswerStudy;

public class CheckAnswerStudyQuery : IRequest<bool>
{
    public string Lang { get; set; }
    public required string UserId { get; set; }
    public required NextQuestionViewModelRequest Request { get; set; }
}