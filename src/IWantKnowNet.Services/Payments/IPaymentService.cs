using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Services.Payments;

public interface IPaymentService
{
    Task<GetTransactionByIdViewModel?> GetTransactionByIdAsync(UserManager<ApplicationUser> userManager,
        ApplicationUser? userAsync, string txId, CancellationToken cancellationToken);
    
    Task<List<PaymentViewModel>?> GetPaymentsByUserIdAsync(string userId, CancellationToken cancellationToken);
}