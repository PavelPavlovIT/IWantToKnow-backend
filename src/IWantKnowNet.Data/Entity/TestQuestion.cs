using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class TestQuestion
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string TestId { get; set; }
    [MaxLength(255)] public required string QuestionsId { get; set; }
    public required DateTimeOffset Created { get; set; }
    public required DateTimeOffset Started { get; set; }
}