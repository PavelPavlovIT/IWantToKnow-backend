using IWantKnowNet.Data.Repositories.IncorrectAnswer;
using MediatR;

namespace Services.IncorrectAnswerService.Commands.UpdateIncorrectAnswer;

public class UpdateIncorrectAnswerHandler() : IRequestHandler<UpdateIncorrectAnswerQuery>
{
    private readonly IIncorrectAnswerRepository? _repository;

    public UpdateIncorrectAnswerHandler(IIncorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(UpdateIncorrectAnswerQuery request, CancellationToken cancellationToken)
    {
        await _repository!.UpdateIncorrectAnswerAsync(request.IncorrectAnswerViewModel, cancellationToken);
    }
}