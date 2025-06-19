using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Payments;
using Services.TeamService;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class TeamController(
    ILogger<TeamController> logger,
    UserManager<ApplicationUser> userManager,
    ITeamService teamService,
    IConfiguration configuration)
    : ApiBaseController(userManager, configuration)
{
    [HttpPost(nameof(AddMember))]
    [Authorize]
    public async Task<IActionResult> AddMember(string mentorId, string email, string nickname)
    {
        try
        {
            if (string.IsNullOrEmpty(mentorId) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nickname))
            {
                return BadRequest("Mentor ID, email, and nickname are required.");
            }

            // Call the AddMemberAsync method from the team service
            await teamService.AddMemberAsync(mentorId, email, nickname, HttpContext.RequestAborted);

            return Ok(new { Message = "Member added successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred while adding a member.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpPost(nameof(AssignTest))]
    [Authorize]
    public async Task<IActionResult> AssignTest(string mentorId, string memberId, string testId)
    {
        try
        {
            if (string.IsNullOrEmpty(mentorId) || string.IsNullOrEmpty(memberId) || string.IsNullOrEmpty(testId))
            {
                return BadRequest("Mentor ID, Member ID, and Test ID are required.");
            }

            // Call the AssignTestAsync method from the team service
            await teamService.AssignTestAsync(mentorId, memberId, testId, HttpContext.RequestAborted);

            return Ok(new { Message = "Test assigned successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred while assigning the test.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpPost(nameof(CancelTest))]
    [Authorize]
    public async Task<IActionResult> CancelTest(string mentorId, string memberId, string assignTestId)
    {
        try
        {
            if (string.IsNullOrEmpty(mentorId) || string.IsNullOrEmpty(memberId) || string.IsNullOrEmpty(assignTestId))
            {
                return BadRequest("Mentor ID, Member ID, and Assigned Test ID are required.");
            }

            // Call the CancelTestAsync method from the team service
            await teamService.CancelTestAsync(mentorId, memberId, assignTestId, HttpContext.RequestAborted);

            return Ok(new { Message = "Test assignment canceled successfully." });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred while canceling the test assignment.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet(nameof(GetMembers))]
    [Authorize]
    public async Task<IActionResult> GetMembers(string mentorId)
    {
        if (string.IsNullOrEmpty(mentorId))
        {
            return BadRequest("Mentor ID is required.");
        }

        try
        {
            // Call the GetMembersAsync method from the team service
            var members = await teamService.GetMembersAsync(mentorId, HttpContext.RequestAborted);

            return Ok(members);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred while retrieving team members.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet(nameof(GetTestResultByMemberId))]
    [Authorize]
    public async Task<IActionResult> GetTestResultByMemberId(string mentorId, string memberId)
    {
        try
        {
            if (string.IsNullOrEmpty(mentorId) || string.IsNullOrEmpty(memberId))
            {
                return BadRequest("Mentor ID and Member ID are required.");
            }

            // Call the GetTestResultByMemberIdAsync method from the team service
            var testResults =
                await teamService.GetTestResultByMemberIdAsync(mentorId, memberId, HttpContext.RequestAborted);

            if (testResults == null || !testResults.Any())
            {
                return NotFound("No test results found for the specified member.");
            }

            return Ok(testResults);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred while retrieving test results.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet(nameof(GetTestsByMemberId))]
    [Authorize]
    public async Task<IActionResult> GetTestsByMemberId(string mentorId, string memberId)
    {
        try
        {
            if (string.IsNullOrEmpty(mentorId) || string.IsNullOrEmpty(memberId))
            {
                return BadRequest("Mentor ID and Member ID are required.");
            }

            // Example service call (Assuming a corresponding method exists in ITeamService)
            var tests = await teamService.GetTestsByMemberIdAsync(mentorId, memberId, HttpContext.RequestAborted);

            if (tests == null || !tests.Any())
            {
                return NotFound("No tests found for the specified member.");
            }

            return Ok(tests);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred while retrieving tests by member ID.");
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}