using IWantKnowNet.Data.Repositories.CorrectAnswer;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CorrectAnswerService.Queries.GetCorrectAnswersByCategoryId;

public class GetCorrectAnswersByCategoryIdHandler()
    : IRequestHandler<GetCorrectAnswersByCategoryIdQuery, IList<CorrectAnswerViewModel>?>
{
    private readonly ICorrectAnswerRepository? _repository;

    public GetCorrectAnswersByCategoryIdHandler(ICorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<IList<CorrectAnswerViewModel>?> Handle(GetCorrectAnswersByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetCorrectAnswersByCategoryIdAsync(request.Lang, request.CategoryId, cancellationToken);
    }
}