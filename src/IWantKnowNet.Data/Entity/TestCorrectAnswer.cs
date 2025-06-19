using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class TestCorrectAnswer
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(1000)] public string? Title { get; set; }
    [MaxLength(255)] public required string TestId { get; set; }
    //TODO need rename QuestionsId to QuestionId
    [MaxLength(255)] public required string QuestionsId { get; set; }
    public required int NumberQuestion { get; set; }
    [MaxLength(255)] public required string CorrectAnswerId { get; set; }
}