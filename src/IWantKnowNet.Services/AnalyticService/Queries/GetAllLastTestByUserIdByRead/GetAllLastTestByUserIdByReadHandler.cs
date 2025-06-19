using IWantKnowNet.Data.Repositories.AnalyticRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.AnalyticService.Queries.GetAllLastTestByUserIdByRead;

namespace Services.AnalyticService.Queries.GetAllLastTestByUserId;

public class GetAllLastTestByUserIdByReadHandler(
    IAnalyticRepository repository
) : IRequestHandler<GetAllLastTestByUserIdByReadQuery, List<GetAllLastTestByUserIdViewModel>?>
{
    public async Task<List<GetAllLastTestByUserIdViewModel>?> Handle(GetAllLastTestByUserIdByReadQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllLastTestByUserIdByReadAsync(
            request.UserId,
            cancellationToken);
    }
}