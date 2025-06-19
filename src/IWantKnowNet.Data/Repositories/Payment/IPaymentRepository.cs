using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.Payment;

public interface IPaymentRepository
{
    Task<bool> CheckTransaction(string userId, string txId, CancellationToken cancellationToken);
    Task AddPaymentAsync(PaymentViewModel model, CancellationToken cancellationToken);
    Task<List<PaymentViewModel>?> GetPaymentsByUserIdAsync(string userId, CancellationToken cancellationToken);
}