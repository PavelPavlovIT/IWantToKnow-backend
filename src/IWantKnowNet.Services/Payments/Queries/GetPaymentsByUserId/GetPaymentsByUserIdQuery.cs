using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.Payments.Queries.GetPaymentsByUserId;

public class GetPaymentsByUserIdQuery: IRequest<List<PaymentViewModel>?>
{
    public required string UserId { get; set; }
}