using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IWantKnowNet.Data.Repositories.Payment;

public class PaymentRepository(
    IDataService dataService,
    ApplicationDbContext context) : IPaymentRepository
{
    public async Task<bool> CheckTransaction(string userId, string txId, CancellationToken cancellationToken)
    {
        return await context.Payments.AnyAsync(i => i.TxId.Equals(txId) && i.Success, cancellationToken);
    }

    public async Task AddPaymentAsync(PaymentViewModel model, CancellationToken cancellationToken)
    {
        var exist = await context.Payments.AnyAsync(i => i.TxId.Equals(model.TxId), cancellationToken);

        if (!exist)
        {
            await context.Payments.AddAsync(new Entity.Payment()
            {
                UserId = model.UserId,
                Id = model.PaymentId,
                Amount = (decimal)model.Amount,
                Created = model.Created,
                TxId = model.TxId,
                Success = (bool)model.Success,
            }, cancellationToken);
        }
        else
        {
            var payment = await context.Payments.FirstOrDefaultAsync(i => i.TxId.Equals(model.TxId), cancellationToken);
            payment.Success = (bool)model.Success;
            payment.Amount = (decimal)model.Amount;
            payment.Created = model.Created;
            context.Payments.Update(payment);
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<PaymentViewModel>?> GetPaymentsByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        //TODO need invistigate how more effective when query after that return + select, or qery + select after thet return result  

        var result = await context.Payments
            .Where(i => i.UserId.Equals(userId))
            .OrderByDescending(i=>i.Created)
            .ToListAsync(cancellationToken);
        return result.Select(i => new PaymentViewModel
        {
            UserId = i.UserId,
            PaymentId = i.Id,
            Amount = i.Amount,
            Created = i.Created,
            TxId = i.TxId,
            Success = i.Success,
        }).ToList();
    }
}