using AutoMapper;
using Binance.Net.Clients;
using Binance.Net.Objects.Models.Spot;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.SharedApis;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Services.BinanceService;

public class BinanceService(
    IDepositRestClient depositRestClient,
    IMapper mapper,
    ILogger<BinanceService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), IBinanceService
{
    public async Task<GetTransactionByIdViewModel?> GetTransactionByIdAsync(string txId, CancellationToken cancellationToken)
    {
        var result = new GetTransactionByIdViewModel()
        {
            TxId = txId,
            Message = "",
            IsSuccess = false,
            Amount = 0
        };

        var binanceClient = new BinanceRestClient(options =>
        {
            options.ApiCredentials = new ApiCredentials(
                "UdWthjMbAkzxikzhYZL9kdCqiQeSBACXdJkgvO6qje5TEw6bsLDlKZwInn3GwbiR",
                "GXEdPV8uv30fX5U7ny6aSVhse0NxJvdRZIaT1p1Ziqw1aLNGTtKTTRim8zu3TDEz");
        });
        var list = await binanceClient.SpotApi.Account.GetDepositHistoryAsync(ct: cancellationToken);
        BinanceDeposit? binanceDeposit =
            (await binanceClient.SpotApi.Account.GetDepositHistoryAsync(ct: cancellationToken))
            .Data.FirstOrDefault(i => i.TransactionId.Equals(txId));

        if (binanceDeposit != null)
        {
            result.Amount = binanceDeposit.Quantity;
            result.IsSuccess = true;
        }

        return await Task.FromResult<GetTransactionByIdViewModel?>(result);
    }
}