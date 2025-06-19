using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class StudyQuestion
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string TestId { get; set; }
    [MaxLength(255)] public required string QuestionsId { get; set; }
    [MaxLength(255)] public required string? UserId { get; set; }
    public DateTimeOffset? Created { get; set; }
    public DateTimeOffset? Started { get; set; }
    public bool? Finished { get; set; }
}