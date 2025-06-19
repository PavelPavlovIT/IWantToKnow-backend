using IWantKnowNet.Data.Repositories.TeamRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.TeamService.Queries.GetTestResultByMemberId;

namespace Services.TeamService.Queries.GetTestsByMemberId;

public class GetTestsByMemberIdHandler(ITeamRepository teamRepository) :
    IRequestHandler<GetTestsByMemberIdQuery, List<TestViewModel>?>
{
    public async Task<List<TestViewModel>?> Handle(GetTestsByMemberIdQuery request, CancellationToken cancellationToken)
    {
        
        return await teamRepository.GetTestsByMemberIdAsync(request.MentorId, request.MemberId, cancellationToken);
    }
}