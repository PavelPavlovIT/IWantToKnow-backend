using AutoMapper;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.TeamService.Commands.AddMember;
using Services.TeamService.Commands.AssignTest;
using Services.TeamService.Commands.CancelTest;
using Services.TeamService.Queries.GetMembers;
using Services.TeamService.Queries.GetTestResultByMemberId;
using Services.TeamService.Queries.GetTestsByMemberId;

namespace Services.TeamService;

public class TeamService(
    IMapper mapper,
    ILogger<TeamService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), ITeamService
{
    public async Task AddMemberAsync(string mentorId, string email, string nickname,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed AddMemberAsync failed";

        try
        {
            await Mediator.Send(
                new AddMemberCommand()
                {
                    MentorId = mentorId,
                    Email = email,
                    Nickname = nickname
                },
                cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
        }
    }

    public async Task AssignTestAsync(string mentorId, string memberId, string testId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed AssignTestAsync failed";

        try
        {
            await Mediator.Send(
                new AssignTestCommand()
                {
                    MentorId = mentorId,
                    MemberId = memberId,
                    TestId = testId
                },
                cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
        }
    }

    public async Task CancelTestAsync(string mentorId, string memberId, string assignTestId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed CancelTestAsync failed";

        try
        {
            await Mediator.Send(
                new CancelTestCommand()
                {
                    MentorId = mentorId,
                    MemberId = memberId,
                    AssignTestId = assignTestId
                },
                cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
        }
    }

    public async Task<List<MemberTeamViewModel>?> GetMembersAsync(string mentorId, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetMembersAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetMembersQuery()
                {
                    MentorId = mentorId
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<List<TestResultViewModel>?> GetTestResultByMemberIdAsync(string mentorId, string memberId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetTestResultByMemberIdAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetTestResultByMemberIdQuery()
                {
                    MentorId = mentorId,
                    MemberId = memberId
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<List<TestViewModel>?> GetTestsByMemberIdAsync(string mentorId, string memberId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetTestsByMemberIdAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetTestsByMemberIdQuery()
                {
                    MentorId = mentorId,
                    MemberId = memberId
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }
}