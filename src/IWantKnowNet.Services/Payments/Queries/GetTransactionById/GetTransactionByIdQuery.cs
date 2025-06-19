using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.Payments.Queries.GetTransactionById;

public class GetTransactionByIdQuery: IRequest<GetTransactionByIdViewModel?>
{
    public required string TxId { get; set; }
    public string? UserId { get; set; }
}