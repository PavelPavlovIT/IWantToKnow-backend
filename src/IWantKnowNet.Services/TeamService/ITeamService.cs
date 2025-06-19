using IWantToKnowNet.Common.ViewModels;

namespace Services.TeamService;

public interface ITeamService
{
    Task AddMemberAsync(
        string mentorId,
        string email,
        string nickname,
        CancellationToken cancellationToken);

    Task AssignTestAsync(
        string mentorId,
        string memberId,
        string testId,
        CancellationToken cancellationToken);

    Task CancelTestAsync(
        string mentorId,
        string memberId,
        string assignTestId,
        CancellationToken cancellationToken);

    Task<List<MemberTeamViewModel>?> GetMembersAsync(
        string mentorId,
        CancellationToken cancellationToken);

    Task<List<TestResultViewModel>?> GetTestResultByMemberIdAsync(
        string mentorId,
        string memberId,
        CancellationToken cancellationToken);

    Task<List<TestViewModel>?> GetTestsByMemberIdAsync(
        string mentorId,
        string memberId,
        CancellationToken cancellationToken);
}