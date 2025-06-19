using IWantKnowNet.Data.Repositories.AnalyticRepository;
using IWantKnowNet.Data.Repositories.Payment;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.AnalyticService.Queries.GetAllLastTestByUserId;
using Services.BinanceService;

namespace Services.Payments.Queries.GetTransactionById;

public class GetTransactionByIdHandler(
    IBinanceService binanceService,
    IPaymentRepository paymentRepository
) : IRequestHandler<GetTransactionByIdQuery, GetTransactionByIdViewModel?>
{
    public async Task<GetTransactionByIdViewModel?> Handle(GetTransactionByIdQuery request,
        CancellationToken cancellationToken)
    {
        if (await paymentRepository.CheckTransaction(request.UserId!, request.TxId, cancellationToken))
        {
            // return new GetTransactionByIdViewModel { Amount = -1, IsSuccess = false, Message = "This transaction has already been used", TxId = request.TxId };
            return new GetTransactionByIdViewModel { Amount = -1, IsSuccess = false, Message = "Эта транзакция была уже использована", TxId = request.TxId };
        }
        var result = await binanceService
            .GetTransactionByIdAsync(
                request.TxId,
                cancellationToken);

        await paymentRepository.AddPaymentAsync(new PaymentViewModel()
        {
            UserId = request.UserId,
            PaymentId = Guid.NewGuid().ToString(),
            Amount = result!.Amount,
            TxId = request.TxId,
            Created = DateTime.UtcNow,
            Success = result!.IsSuccess
        }, cancellationToken);

        if (!result.IsSuccess)
            // result.Message = "Transaction not found";
            result.Message = "Транзакция не найдена";
        return result;
    }
}