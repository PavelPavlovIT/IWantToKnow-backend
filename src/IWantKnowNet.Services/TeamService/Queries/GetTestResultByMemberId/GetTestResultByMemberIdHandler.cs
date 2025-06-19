using IWantKnowNet.Data.Repositories.TeamRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TeamService.Queries.GetTestResultByMemberId;

public class GetTestResultByMemberIdHandler(ITeamRepository teamRepository) :
    IRequestHandler<GetTestResultByMemberIdQuery, List<TestResultViewModel>?>
{
    public async Task<List<TestResultViewModel>?> Handle(GetTestResultByMemberIdQuery request,
        CancellationToken cancellationToken)
    {
        return await teamRepository.GetTestResultByMemberIdAsync(request.MentorId, request.MemberId, cancellationToken);
    }
}