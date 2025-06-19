using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class TestResult
{
    [MaxLength(255)] public required string Id { get; init; }
    public required int CorrectAnswersCount { get; set; }
    public required int TestQuestionCount { get; set; }

    [MaxLength(255)] public required string TestId { get; set; }
    public Test? Test { get; set; }
    public ICollection<TestResultDetail>? TestResultDetails { get; }

}

