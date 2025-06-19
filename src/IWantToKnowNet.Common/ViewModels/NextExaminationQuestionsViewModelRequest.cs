namespace IWantToKnowNet.Common.ViewModels;

public class NextExaminationQuestionViewModelRequest
{
    public required string ExamenId { get; init; }
    public required string CategoryId { get; init; }
    public string? QuestionId { get; set; }
    public IList<string>? ListOfCorrectAnswers { get; set; }
    public bool ExpiredTime { get; set; } = false;
}
