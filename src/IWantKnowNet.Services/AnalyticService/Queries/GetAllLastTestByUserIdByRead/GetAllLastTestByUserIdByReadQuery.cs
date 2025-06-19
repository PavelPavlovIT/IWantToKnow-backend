using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.AnalyticService.Queries.GetAllLastTestByUserIdByRead;

public class GetAllLastTestByUserIdByReadQuery: IRequest<List<GetAllLastTestByUserIdViewModel>?>
{
    public required string UserId { get; set; }
}