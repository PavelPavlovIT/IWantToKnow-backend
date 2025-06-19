namespace IWantToKnowNet.Common.ViewModels;

public class TestResultViewModel
{
    public required string TestId { get; set; }
    public required string TypeTestId { get; set; }
    public required string TestResultId { get; set; }
    public string? DateStarted { get; set; }
    public string? TimeStarted { get; set; }
    public required string CategoryName { get; set; }
    public string CategoryId { get; set; }
    public int? CorrectAnswersCount { get; set; }
    public int? TestQuestionCount { get; set; }
    
}