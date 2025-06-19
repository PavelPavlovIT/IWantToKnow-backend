using MediatR;

namespace Services.TeamService.Commands.CancelTest;

public class CancelTestCommand: IRequest
{
    public required string MentorId { get; set; }
    public required string MemberId { get; set; }
    public required string AssignTestId { get; set; }
}