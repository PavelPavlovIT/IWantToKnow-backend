using IWantKnowNet.Data.Repositories.TeamRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TeamService.Queries.GetMembers;

public class GetMembersHandler(ITeamRepository teamRepository): 
    IRequestHandler<GetMembersQuery, List<MemberTeamViewModel>?>
{
    public async Task<List<MemberTeamViewModel>?> Handle(GetMembersQuery request, CancellationToken cancellationToken)
    {
        var members = await teamRepository.GetMembersAsync(request.MentorId, cancellationToken);
        return members;
    }
}