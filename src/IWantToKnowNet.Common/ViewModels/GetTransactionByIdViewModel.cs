namespace IWantToKnowNet.Common.ViewModels;

public class GetTransactionByIdViewModel
{
    public string? TxId { get; set; }
    public required bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public required decimal Amount { get; set; }
}