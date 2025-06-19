namespace IWantToKnowNet.Common.ViewModels;

public class StartTestViewModel: ResponseViewModel
{
    public  required string TestId { get; init; }
    public  string? TypeTestId { get; init; }
    public  string? CategoryId { get; init; }
    public  string? CategoryName { get; set; }
    public  int? CountQuestion { get; init; }
    public DateTimeOffset? Created { get; set; }
    public NextQuestionViewModel? NextQuestionViewModel { get; set; }
    
}