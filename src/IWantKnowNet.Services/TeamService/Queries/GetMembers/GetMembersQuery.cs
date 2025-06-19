using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TeamService.Queries.GetMembers;

public class GetMembersQuery: IRequest<List<MemberTeamViewModel>?>
{
    public required string MentorId { get; set; }
}