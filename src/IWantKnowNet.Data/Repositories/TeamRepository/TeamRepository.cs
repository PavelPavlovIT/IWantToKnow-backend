using System.Globalization;
using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace IWantKnowNet.Data.Repositories.TeamRepository;

public class TeamRepository(
    IDataService dataService,
    ApplicationDbContext context) : ITeamRepository
{
    public async Task AddMemberAsync(
        string mentorId,
        string email,
        string nickname,
        CancellationToken cancellationToken)
    {

        var user = await context.ApplicationUsers
            .Where(i => i.Email!.Equals(email))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (user == null)
        {
            await context.MemberTeams.AddAsync(new MemberTeam()
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                Nickname = nickname,
                IsActive = true,
                MentorId = mentorId,
            }, cancellationToken);
        }
        else
        {
            await context.MemberTeams.AddAsync(new MemberTeam()
            {
                Id = Guid.NewGuid().ToString(),
                Email = email,
                Nickname = nickname,
                IsActive = true,
                MentorId = mentorId,
                MemeberId = user.Id,
            }, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<MemberTeamViewModel>?> GetMembersAsync(string mentorId, CancellationToken cancellationToken)
    {

        var list = await (
            from memberTeam in context.MemberTeams
            join user in context.ApplicationUsers on memberTeam.MemeberId equals user.Id
            where memberTeam.MentorId.Equals(mentorId)
            select new MemberTeamViewModel
            {
                UserId = user.Id,
                Email = memberTeam.Email,
                Nickname = memberTeam.Nickname
            }).ToListAsync(cancellationToken);
        
        return list;
    }

    public async Task AssignTestAsync(string mentorId, string memberId, string testId, CancellationToken cancellationToken)
    {

        await context.AssignTests.AddAsync(new AssignTest()
        {
            Id = Guid.NewGuid().ToString(),
            MentorId = mentorId,
            MemberId = memberId,
            TestId = testId,
            Created =  DateTimeOffset.Now
        }, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
        
    }

    public async Task CancelTestAsync(string mentorId, string memberId, string assignTestId, CancellationToken cancellationToken)
    {

        await context.AssignTests
            .Where(i=>i.Id.Equals(assignTestId))
            .ExecuteUpdateAsync(item=>item.SetProperty(p=>p.Canceled, DateTimeOffset.Now), cancellationToken: cancellationToken);
    }

    public async Task<List<TestViewModel>?> GetTestsByMemberIdAsync(string mentorId, string memberId, CancellationToken cancellationToken)
    {

        var list = await (
            from memberTeam in context.MemberTeams
            join user in context.ApplicationUsers on memberTeam.MemeberId equals user.Id
            join assignTest in context.AssignTests on memberTeam.MemeberId equals assignTest.MemberId
            join test in context.Tests on assignTest.TestId equals test.Id
            where memberTeam.MentorId.Equals(mentorId) 
            && memberTeam.MemeberId.Equals(memberId)
            select new TestViewModel
            {
                UserId = user.Id,
                TestId = test.Id,
                CategoryName = test.CategoryName
            }).ToListAsync(cancellationToken);
        
        return list;
    }

    public async Task<List<TestResultViewModel>?> GetTestResultByMemberIdAsync(string mentorId, string memberId, CancellationToken cancellationToken)
    {

        var list =await (
            from memberTeam in context.MemberTeams
            join user in context.ApplicationUsers on memberTeam.MemeberId equals user.Id
            join assignTest in context.AssignTests on memberTeam.MemeberId equals assignTest.MemberId
            join test in context.Tests on assignTest.TestId equals test.Id
            join testResult in context.TestResults on test.Id equals testResult.TestId 
            where memberTeam.MentorId.Equals(mentorId) 
                  && memberTeam.MemeberId.Equals(memberId)
            select new TestResultViewModel
            {
                TestId = test.Id,
                TypeTestId = test.TypeTestId,
                CategoryName = test.CategoryName,
                TestResultId = testResult.Id,
                DateStarted = test.Started.Value.Date.ToString(CultureInfo.InvariantCulture),
                TimeStarted = test.Started.Value.ToUniversalTime().ToString(),
                TestQuestionCount = testResult.TestQuestionCount,
                CorrectAnswersCount = testResult.CorrectAnswersCount,
                
            }).ToListAsync(cancellationToken);
        
        return list;
    }
}