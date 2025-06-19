using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

//TODO Who is it?
public class TestAnswer
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string TestId { get; set; }
    [MaxLength(255)] public required string QuestionsId { get; set; }
    public required int NumberQuestion { get; set; }
    [MaxLength(255)] public required string CorrectAnswerId { get; set; }
    public required bool IsCorrect { get; set; }

}