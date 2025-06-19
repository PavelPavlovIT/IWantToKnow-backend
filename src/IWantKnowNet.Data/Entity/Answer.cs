using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class Answer
{
    [MaxLength(255)] public required string Id { get; set; }
    public int? Seconds { get; set; }
    public required int NumberQuestion { get; set; }
    public required bool ExpiredTime { get; set; }

    [MaxLength(1000)] public string? TextSpeaking { get; set; }
    [MaxLength(255)] public required string TestId { get; set; }
    public Test? Test { get; set; }
    [MaxLength(255)] public required string QuestionId { get; set; }
    public Question? Question { get; set; }
    [MaxLength(255)] public required string CorrectAnswerId { get; set; }
}