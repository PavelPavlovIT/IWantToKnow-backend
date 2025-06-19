using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Services.Payments.Queries.GetPaymentsByUserId;
using Services.Payments.Queries.GetTransactionById;

namespace Services.Payments;

public class PaymentService(
    RoleManager<IdentityRole> roleManager,
    IMapper mapper,
    ILogger<PaymentService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), IPaymentService
{
    public async Task<GetTransactionByIdViewModel?> GetTransactionByIdAsync(
        UserManager<ApplicationUser> userManager,
        ApplicationUser? user,
        string txId, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetTransactionByIdAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetTransactionByIdQuery()
                {
                    UserId = user!.Id,
                    TxId = txId
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<List<PaymentViewModel>?> GetPaymentsByUserIdAsync(string userId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetPaymentsByUserIdAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetPaymentsByUserIdQuery()
                {
                    UserId = userId
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }
}