namespace IWantToKnowNet.Common.ViewModels;

public class GetAllLastTestByUserIdViewModel
{
    public  string? CategoryId { get; set; }
    public  string? CategoryName { get; set; }
    public  TestResultViewModel[] Results  { get; set; }
}