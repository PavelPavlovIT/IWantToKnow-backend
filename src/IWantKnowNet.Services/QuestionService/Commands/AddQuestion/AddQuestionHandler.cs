using IWantKnowNet.Data.Repositories.Question;
using MediatR;

namespace Services.QuestionService.Commands.AddQuestion;

public class AddQuestionHandler() : IRequestHandler<AddQuestionQuery>
{
    private readonly IQuestionRepository? _repository;

    public AddQuestionHandler(IQuestionRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(AddQuestionQuery request, CancellationToken cancellationToken)
    {
        await _repository!.AddQuestionAsync(request.QuestionViewModel, cancellationToken);
    }
}