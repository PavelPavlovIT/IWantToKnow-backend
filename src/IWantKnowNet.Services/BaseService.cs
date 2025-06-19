using MediatR;
using Microsoft.Extensions.Logging;

namespace Services;

public class BaseService(
    ILogger<BaseService> logger,
    IMediator mediator)
{
    protected IMediator Mediator { get; } = mediator;
    protected readonly ILogger<BaseService> Logger = logger;
}