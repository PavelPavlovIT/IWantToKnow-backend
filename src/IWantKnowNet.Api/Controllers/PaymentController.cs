using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.AnalyticService;
using Services.Payments;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class PaymentController(
    ILogger<PaymentController> logger,
    UserManager<ApplicationUser> userManager,
    IPaymentService paymentService,
    IConfiguration configuration)
    : ApiBaseController(userManager, configuration)
{
    [HttpPost]
    [Route("GetTransactionById")]
    [Authorize]
    public async Task<GetTransactionByIdViewModel> GetTransactionByIdAsync(
        GetTransactionByIdRequest model,
        CancellationToken cancellationToken)
    {
        var result = await paymentService.GetTransactionByIdAsync(
            userManager,
            await UserManager.GetUserAsync(User),
            model.TxId,
            CancellationToken.None);
        var user = await UserManager.GetUserAsync(User);
        if (user!.ExpireDateTime == null)
        {
            user.ExpireDateTime = DateTime.UtcNow;
            await userManager.UpdateAsync(user);
        }

        if (result!.IsSuccess && result.Amount > 0)
        {
            
            if (result.Amount < 30)
            {
                var sec = Decimal.ToDouble(result.Amount * 8640);
                var value = user.ExpireDateTime.Value;
                if (value < DateTime.UtcNow)
                    user.ExpireDateTime = DateTime.UtcNow.AddSeconds(sec);
                else
                    user.ExpireDateTime = value.AddSeconds(sec);
            }
            else
            {
                var sec = Decimal.ToDouble(result.Amount * 86400);
                var value = user.ExpireDateTime.Value;
                if (user.ExpireDateTime < DateTime.UtcNow)
                    user.ExpireDateTime = DateTime.UtcNow.AddSeconds(sec);
                else
                    user.ExpireDateTime = value.AddSeconds(sec);
            }
            await userManager.UpdateAsync(user);
        }

        return result;
    }

    [HttpGet]
    [Route("GetPaymentsByUserId")]
    [Authorize]
    public async Task<List<PaymentViewModel>?> GetPaymentsByUserIdAsync(
        CancellationToken cancellationToken)
    {
        var result = await paymentService.GetPaymentsByUserIdAsync(
            (await UserManager.GetUserAsync(User)).Id,
            CancellationToken.None);

        return result;
    }
}