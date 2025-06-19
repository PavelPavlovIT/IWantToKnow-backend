namespace IWantToKnowNet.Common.ViewModels;

public class NextQuestionViewModelRequest
{
    public required string TestId { get; set; }
    public string TypeTestId { get; set; } = "";
    public bool SpeakingResult { get; set; } = false;
    public string? TextSpeaking { get; set; }
    public required string CategoryId { get; set; }
    public NextQuestionViewModel? NextQuestionViewModel { get; set; }
    public int NumberQuestion { get; set; } = 60;
    public int CountQuestions { get; set; } = 60;
    public bool Finished { get; set; } = false;
    
}