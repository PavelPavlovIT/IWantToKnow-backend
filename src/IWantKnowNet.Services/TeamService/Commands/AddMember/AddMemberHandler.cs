using IWantKnowNet.Data.Repositories.TeamRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.TestService.Commands.StartTest;

namespace Services.TeamService.Commands.AddMember;

public class AddMemberHandler(ITeamRepository teamRepository): 
    IRequestHandler<AddMemberCommand>
{
    public async Task Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        await teamRepository.AddMemberAsync(request.MentorId, request.Email, request.Nickname, cancellationToken);
    }
}