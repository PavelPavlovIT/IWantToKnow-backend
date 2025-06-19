using MediatR;
using Services.TestService.Commands.GetPreSignedURL;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationTestHandlers
{
    public static IServiceCollection AddTestHandlers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IRequestHandler<GetPreSignedURLCommand,
                    (string, DateTime)>,
                GetPreSignedURLHandler>()
            ;
    }
}