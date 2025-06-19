using IWantKnowNet.Data.Repositories.CorrectAnswer;
using MediatR;

namespace Services.CorrectAnswerService.Commands.UpdateCorrectAnswer;

public class UpdateCorrectAnswerHandler() : IRequestHandler<UpdateCorrectAnswerQuery>
{
    private readonly ICorrectAnswerRepository? _repository;

    public UpdateCorrectAnswerHandler(ICorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCorrectAnswerQuery request, CancellationToken cancellationToken)
    {
        await _repository!.UpdateCorrectAnswerAsync(request.CorrectAnswerViewModel, cancellationToken);
    }
}