using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

//TODO Who is it?
public class TestIncorrectAnswer
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string TestId { get; set; }
    [MaxLength(255)] public required string QuestionsId { get; set; }
    [MaxLength(255)] public required string IncorrectAnswerId { get; set; }
}