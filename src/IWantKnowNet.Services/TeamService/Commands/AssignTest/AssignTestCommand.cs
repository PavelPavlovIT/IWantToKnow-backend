using MediatR;

namespace Services.TeamService.Commands.AssignTest;

public class AssignTestCommand: IRequest
{
    public required string MentorId { get; set; }
    public required string MemberId { get; set; }
    public required string TestId { get; set; }
}