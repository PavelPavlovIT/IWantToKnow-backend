using IWantKnowNet.Data.Repositories.TestRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TestService.Commands.StartTest;

public class StartTestHandler(ITestRepository repository)
    : IRequestHandler<StartTestCommand, StartTestViewModel?>
{
    public async Task<StartTestViewModel?> Handle(StartTestCommand request, CancellationToken cancellationToken)
    {
        return await repository!.StartTestAsync(
            request.Lang,
            request.UserId,
            request.StartTestViewModel,
            request.StartTestViewModel.CountQuestion,
            cancellationToken);
    }
}