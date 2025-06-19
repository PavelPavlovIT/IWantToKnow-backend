using IWantKnowNet.Data.Repositories.Payment;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.Payments.Queries.GetPaymentsByUserId;

public class GetPaymentsByUserIdHandler(
    IPaymentRepository paymentRepository
    ) : IRequestHandler<GetPaymentsByUserIdQuery, List<PaymentViewModel>?>
{
    public async Task<List<PaymentViewModel>?> Handle(GetPaymentsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await paymentRepository.GetPaymentsByUserIdAsync(request.UserId, cancellationToken);
    }
}