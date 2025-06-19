using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class TestResultDetail
{
    [MaxLength(255)] public required string Id { get; init; }
    [MaxLength(500)] public required string QuestionTitle { get; set; }
    [MaxLength(255)] public string? CorrectAnswerId { get; set; }
    [MaxLength(255)] public string? IncorrectAnswerId { get; set; }

    [MaxLength(255)] public required string TestResultId { get; init; }
    public TestResult? TestResult { get; init; }

    [MaxLength(255)] public required string QuestionId { get; set; }
    public Question? Question { get; set; }
}