using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TeamService.Queries.GetTestResultByMemberId;

public class GetTestResultByMemberIdQuery: IRequest<List<TestResultViewModel>>
{
    public required string MentorId { get; set; }
    public required string MemberId { get; set; }
}