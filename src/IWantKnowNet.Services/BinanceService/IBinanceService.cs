using IWantToKnowNet.Common.ViewModels;

namespace Services.BinanceService;

public interface IBinanceService
{
    Task<GetTransactionByIdViewModel?> GetTransactionByIdAsync(string txId, CancellationToken cancellationToken);
}