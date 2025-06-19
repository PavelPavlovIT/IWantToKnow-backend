using IWantKnowNet.Data.Repositories.CorrectAnswer;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CorrectAnswerService.Queries.GetCorrectAnswersByQuestionId;

public class GetCorrectAnswersByQuestionIdHandler()
    : IRequestHandler<GetCorrectAnswersByQuestionIdQuery, IList<CorrectAnswerViewModel>?>
{
    private readonly ICorrectAnswerRepository? _repository;

    public GetCorrectAnswersByQuestionIdHandler(ICorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<IList<CorrectAnswerViewModel>?> Handle(GetCorrectAnswersByQuestionIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetCorrectAnswersByQuestionIdAsync(request.Lang, request.QuestionId, cancellationToken);
    }
}