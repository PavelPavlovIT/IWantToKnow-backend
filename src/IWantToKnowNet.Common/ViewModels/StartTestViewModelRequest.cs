namespace IWantToKnowNet.Common.ViewModels;

public class StartTestViewModelRequest
{
    public required string TestId { get; init; }
    public required string? TypeTestId { get; init; }
    public required string? CategoryId { get; init; }
    public required string? CategoryName { get; init; }
    public required int? CountQuestion { get; init; }
    public DateTimeOffset? Created { get; set; }

    public StartTestViewModel ToStartTestViewModel()
    {
        return new StartTestViewModel
        {
            TestId = TestId,
            TypeTestId = TypeTestId,
            CategoryId = CategoryId,
            CategoryName = CategoryName,
            CountQuestion = CountQuestion,
            Created = Created
        };
    }
}