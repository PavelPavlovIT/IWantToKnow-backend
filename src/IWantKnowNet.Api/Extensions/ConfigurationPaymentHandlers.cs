using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.Payments.Queries.GetPaymentsByUserId;
using Services.Payments.Queries.GetTransactionById;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationPaymentHandlers
{
    public static IServiceCollection AddPaymentsHandlers(
        this IServiceCollection services)
    {
        return services
                .AddTransient<IRequestHandler<GetTransactionByIdQuery,
                        GetTransactionByIdViewModel?>,
                    GetTransactionByIdHandler>()
                .AddTransient<IRequestHandler<GetPaymentsByUserIdQuery,
                        List<PaymentViewModel>?>,
                    GetPaymentsByUserIdHandler>()
            ;
    }
}