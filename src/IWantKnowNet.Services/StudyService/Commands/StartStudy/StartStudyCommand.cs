using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.StudyService.Commands.StartStudy;

public class StartStudyCommand : IRequest<StartTestViewModel?>
{
    public string? Lang { get; set; }
    public string? UserId { get; set; }
    public string? CategoryId { get; set; }
    public string TypeTestId { get; internal set; }
}