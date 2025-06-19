using IWantKnowNet.Data.Repositories.Question;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.QuestionService.Queries.GetQuestionByQuestionId;

public class GetQuestionByQuestionIdHandler() : IRequestHandler<GetQuestionByQuestionIdQuery, QuestionViewModel?>
{
    private readonly IQuestionRepository? _repository;

    public GetQuestionByQuestionIdHandler(IQuestionRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<QuestionViewModel?> Handle(GetQuestionByQuestionIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetQuestionsByQuestionIdAsync(request.Lang, request.QuestionId, cancellationToken);
    }
}