namespace IWantToKnowNet.Common.ViewModels;

public class CorrectAnswerViewModel
{
    public required string CorrectAnswerId { get; set; }
    public required int IsTerm { get; set; }
    public required string QuestionId { get; set; }
    public required string TitleEn { get; set; }
    public required string TitleEs { get; set; }
    public required string TitleRu { get; set; }
    public string? CreaterId { get; set; }
    public string? ApproverId { get; set; }
    public int? Seconds { get; set; }
}
