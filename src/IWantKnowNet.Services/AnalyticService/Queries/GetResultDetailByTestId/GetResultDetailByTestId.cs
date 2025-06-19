using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.AnalyticService.Queries.GetResultDetailByTestId;

public class GetResultDetailByTestId: IRequest<IList<TestResultDetailsViewModel>?>
{
    public required string TestId { get; set; }
    public string Lang { get; set; }
}