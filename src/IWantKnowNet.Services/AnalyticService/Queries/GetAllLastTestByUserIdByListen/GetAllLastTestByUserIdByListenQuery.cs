using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.AnalyticService.Queries.GetAllLastTestByUserIdByListen;

public class GetAllLastTestByUserIdByListenQuery: IRequest<List<GetAllLastTestByUserIdViewModel>?>
{
    public required string UserId { get; set; }
}