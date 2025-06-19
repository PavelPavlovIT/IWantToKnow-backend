using IWantKnowNet.Data.Repositories.AnalyticRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdByListen;

namespace Services.AnalyticService.Queries.GetAllLastTestByUserId;

public class GetAllLastTestByUserIdByListenHandler(
    IAnalyticRepository repository
) : IRequestHandler<GetAllLastTestByUserIdByListenQuery, List<GetAllLastTestByUserIdViewModel>?>
{
    public async Task<List<GetAllLastTestByUserIdViewModel>?> Handle(GetAllLastTestByUserIdByListenQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllLastTestByUserIdByListenAsync(
            request.UserId,
            cancellationToken);
    }
}