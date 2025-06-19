using IWantKnowNet.Data.Repositories.AnalyticRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.AnalyticService.Queries.GetResultDetailByTestId;

public class GetResultDetailByTestIdHandler(
    IAnalyticRepository repository
) : IRequestHandler<GetResultDetailByTestId, IList<TestResultDetailsViewModel>?>
{
    public async Task<IList<TestResultDetailsViewModel>?> Handle(GetResultDetailByTestId request,
        CancellationToken cancellationToken)
    {
        return await repository.GetResultDetailByTestIdAsync(
            request.Lang,
            request.TestId,
            cancellationToken);
    }
}