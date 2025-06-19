using IWantKnowNet.Data.Repositories.IncorrectAnswer;
using MediatR;

namespace Services.IncorrectAnswerService.Commands.AddIncorrectAnswer;

public class AddIncorrectAnswerHandler() : IRequestHandler<AddIncorrectAnswerQuery>
{
    private readonly IIncorrectAnswerRepository? _repository;

    public AddIncorrectAnswerHandler(IIncorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(AddIncorrectAnswerQuery request, CancellationToken cancellationToken)
    {
        await _repository!.AddIncorrectAnswerAsync(request.IncorrectAnswerViewModel, cancellationToken);
    }
}