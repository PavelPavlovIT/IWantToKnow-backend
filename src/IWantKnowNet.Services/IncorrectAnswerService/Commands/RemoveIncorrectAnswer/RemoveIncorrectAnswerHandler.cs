using IWantKnowNet.Data.Repositories.IncorrectAnswer;
using MediatR;

namespace Services.IncorrectAnswerService.Commands.RemoveIncorrectAnswer;

public class RemoveIncorrectAnswerHandler() : IRequestHandler<RemoveIncorrectAnswerQuery>
{
    private readonly IIncorrectAnswerRepository? _repository;

    public RemoveIncorrectAnswerHandler(IIncorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(RemoveIncorrectAnswerQuery request, CancellationToken cancellationToken)
    {
        await _repository!.RemoveIncorrectAnswerAsync(request.IncorrectAnswerViewModel, cancellationToken);
    }
}