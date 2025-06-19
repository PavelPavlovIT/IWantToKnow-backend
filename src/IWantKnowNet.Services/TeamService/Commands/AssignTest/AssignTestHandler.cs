using IWantKnowNet.Data.Repositories.TeamRepository;
using MediatR;

namespace Services.TeamService.Commands.AssignTest;

public class AssignTestHandler(ITeamRepository teamRepository): 
    IRequestHandler<AssignTestCommand>
{
    public async Task Handle(AssignTestCommand request, CancellationToken cancellationToken)
    {
        await teamRepository.AssignTestAsync(request.MentorId, request.MemberId, request.TestId, cancellationToken);
    }
}