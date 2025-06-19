using IWantKnowNet.Data.Repositories.TeamRepository;
using MediatR;

namespace Services.TeamService.Commands.CancelTest;

public class CancelTestHandler(ITeamRepository teamRepository): 
    IRequestHandler<CancelTestCommand>
{
    public async Task Handle(CancelTestCommand request, CancellationToken cancellationToken)
    {
        await teamRepository.CancelTestAsync(request.MentorId, request.MemberId, request.AssignTestId, cancellationToken);
    }
}