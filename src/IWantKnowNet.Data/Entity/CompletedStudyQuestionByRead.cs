using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class CompletedStudyQuestionByRead
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string QuestionId { get; set; }
    [MaxLength(255)] public required string UserId { get; set; }
    public required int QuantityCorrectAnswersOfQuestion { get; set; }
}