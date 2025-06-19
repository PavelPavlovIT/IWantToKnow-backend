using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TeamService.Queries.GetTestsByMemberId;

public class GetTestsByMemberIdQuery: IRequest<List<TestViewModel>?>
{
    public required string MentorId { get; set; }
    public required string MemberId { get; set; }
}