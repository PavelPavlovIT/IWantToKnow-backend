namespace IWantToKnowNet.Common.ViewModels;

public class PaymentViewModel
{
    public string? UserId { get; set; }
    public string? PaymentId { get; set; }
    public DateTime Created { get; set; }
    public string? TxId { get; set; }
    public decimal? Amount { get; set; }
    public bool? Success { get; set; }
}