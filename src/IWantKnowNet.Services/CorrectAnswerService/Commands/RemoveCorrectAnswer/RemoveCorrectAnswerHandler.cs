using IWantKnowNet.Data.Repositories.CorrectAnswer;
using MediatR;

namespace Services.CorrectAnswerService.Commands.RemoveCorrectAnswer;

public class RemoveCorrectAnswerHandler() : IRequestHandler<RemoveCorrectAnswerQuery>
{
    private readonly ICorrectAnswerRepository? _repository;

    public RemoveCorrectAnswerHandler(ICorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCorrectAnswerQuery request, CancellationToken cancellationToken)
    {
        await _repository!.RemoveCorrectAnswerAsync(
            request.CorrectAnswerViewModel, cancellationToken);
    }
}