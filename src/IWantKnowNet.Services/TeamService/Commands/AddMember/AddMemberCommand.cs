using MediatR;

namespace Services.TeamService.Commands.AddMember;

public class AddMemberCommand: IRequest
{
    public required string MentorId { get; set; }
    public required string Email { get; set; }
    public required string Nickname { get; set; }
}