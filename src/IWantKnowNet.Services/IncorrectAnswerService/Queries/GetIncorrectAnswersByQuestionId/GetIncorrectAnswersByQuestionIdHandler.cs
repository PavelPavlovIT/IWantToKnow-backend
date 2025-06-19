using IWantKnowNet.Data.Repositories.IncorrectAnswer;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByQuestionId;

public class GetIncorrectAnswersByQuestionIdHandler()
    : IRequestHandler<GetIncorrectAnswersByQuestionIdQuery, IList<IncorrectAnswerViewModel>?>
{
    private readonly IIncorrectAnswerRepository? _repository;

    public GetIncorrectAnswersByQuestionIdHandler(IIncorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<IList<IncorrectAnswerViewModel>?> Handle(GetIncorrectAnswersByQuestionIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetIncorrectAnswersByQuestionIdAsync(request.QuestionId, cancellationToken);
    }
}