using IWantKnowNet.Data.Repositories.CorrectAnswer;
using MediatR;

namespace Services.CorrectAnswerService.Commands.AddCorrectAnswer;

public class AddCorrectAnswerHandler() : IRequestHandler<AddCorrectAnswerQuery>
{
    private readonly ICorrectAnswerRepository? _repository;

    public AddCorrectAnswerHandler(ICorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(AddCorrectAnswerQuery request, CancellationToken cancellationToken)
    {
        await _repository!.AddCorrectAnswerAsync(request.CorrectAnswerViewModel, cancellationToken);
    }
}