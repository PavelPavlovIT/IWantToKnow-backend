using IWantKnowNet.Data.Repositories.AnalyticRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdByListen;

namespace Services.AnalyticService.Queries.GetAllLastTestByUserIdBySpeaking;

public class GetAllLastTestByUserIdBySpeakingHandler(
    IAnalyticRepository repository
) : IRequestHandler<GetAllLastTestByUserIdBySpeakingQuery, List<GetAllLastTestByUserIdViewModel>?>
{
    public async Task<List<GetAllLastTestByUserIdViewModel>?> Handle(GetAllLastTestByUserIdBySpeakingQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllLastTestByUserIdBySpeakingAsync(
            request.UserId,
            cancellationToken);
    }
}