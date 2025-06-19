using IWantKnowNet.Data.Repositories.Question;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.QuestionService.Queries.GetQuestionsByCategoryId;

public class GetQuestionsByCategoryIdHandler()
    : IRequestHandler<GetQuestionsByCategoryIdQuery, IList<QuestionViewModel>?>
{
    private readonly IQuestionRepository? _repository;

    public GetQuestionsByCategoryIdHandler(IQuestionRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<IList<QuestionViewModel>?> Handle(GetQuestionsByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetQuestionsByCategoryIdAsync(request.Lang, request.CategoryId, cancellationToken);
    }
}