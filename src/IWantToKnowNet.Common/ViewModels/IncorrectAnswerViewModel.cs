namespace IWantToKnowNet.Common.ViewModels;

public record IncorrectAnswerViewModel(
    string IncorrectAnswerId,
    string QuestionId,
    string Title,
    string? CreaterId,
    string? ApproverId,
    string? Created,
    string? Changed
);