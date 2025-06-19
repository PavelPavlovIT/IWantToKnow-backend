using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.AnalyticService.Queries.GetAllLastTestByUserIdBySpeaking;

public class GetAllLastTestByUserIdBySpeakingQuery: IRequest<List<GetAllLastTestByUserIdViewModel>?>
{
    public required string UserId { get; set; }
}