namespace IWantToKnowNet.Common.ViewModels;

public class NextQuestionViewModel
{
    public required QuestionViewModel QuestionViewModel { get; set; }
    public List<CorrectAnswerViewModel>? InputOfAnswers { get; set; }
    public List<CorrectAnswerViewModel>? ListOfAnswers { get; set; }
    public DateTimeOffset? Started { get; set; }
    public bool ExpiredTime { get; set; } = false;
    public int NumberQuestion { get; set; } = 60;
}
