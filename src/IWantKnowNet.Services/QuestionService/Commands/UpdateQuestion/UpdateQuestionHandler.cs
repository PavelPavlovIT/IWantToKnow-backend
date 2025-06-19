using IWantKnowNet.Data.Repositories.Question;
using MediatR;

namespace Services.QuestionService.Commands.UpdateQuestion;

public class UpdateQuestionHandler() : IRequestHandler<UpdateQuestionQuery>
{
    private readonly IQuestionRepository? _repository;

    public UpdateQuestionHandler(IQuestionRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(UpdateQuestionQuery request, CancellationToken cancellationToken)
    {
        await _repository!.UpdateQuestionAsync(request.QuestionViewModel, cancellationToken);
    }
}