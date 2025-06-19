namespace IWantToKnowNet.Common.ViewModels;

public class NextExaminationQuestionViewModel
{
    public IList<QuestionViewModel>? ListOfQuestions { get; set; }
    public IList<string>? ListOfCorrectAnswers { get; set; }
    public DateTimeOffset? DateTime { get; set; }
}
