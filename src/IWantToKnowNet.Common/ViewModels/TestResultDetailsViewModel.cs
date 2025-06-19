namespace IWantToKnowNet.Common.ViewModels;

public class TestResultDetailsViewModel
{
    public string? TestResultDetailId { get; set; }
    public string? TestResultId { get; set; }
    public string? CategoryId { get; set; }
    public string? QuestionId { get; set; }
    public string? Question { get; set; }
    public string? CorrectAnswerId { get; set; }
    public string? CorrectAnswerTitle { get; set; }
    public string? IncorrectAnswerId { get; set; }
    public string? IncorrectAnswerTitle { get; set; }
    
    public string? Proof { get; set; }
    public bool? IsCorrectAnswer { get; set; }
}