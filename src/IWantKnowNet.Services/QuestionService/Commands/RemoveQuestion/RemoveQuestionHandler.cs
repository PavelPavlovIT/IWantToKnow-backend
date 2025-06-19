using IWantKnowNet.Data.Repositories.Question;
using MediatR;

namespace Services.QuestionService.Commands.RemoveQuestion;

public class RemoveQuestionHandler() : IRequestHandler<RemoveQuestionQuery>
{
    private readonly IQuestionRepository? _repository;

    public RemoveQuestionHandler(IQuestionRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(RemoveQuestionQuery request, CancellationToken cancellationToken)
    {
        await _repository!.RemoveQuestionAsync(request.QuestionViewModel, cancellationToken);
    }
}