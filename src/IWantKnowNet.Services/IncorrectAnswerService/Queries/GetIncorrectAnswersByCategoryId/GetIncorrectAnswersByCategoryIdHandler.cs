using IWantKnowNet.Data.Repositories.IncorrectAnswer;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.IncorrectAnswerService.Queries.GetIncorrectAnswersByCategoryId;

public class GetIncorrectAnswersByCategoryIdHandler()
    : IRequestHandler<GetIncorrectAnswersByCategoryIdQuery, IList<IncorrectAnswerViewModel>?>
{
    private readonly IIncorrectAnswerRepository? _repository;

    public GetIncorrectAnswersByCategoryIdHandler(IIncorrectAnswerRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<IList<IncorrectAnswerViewModel>?> Handle(GetIncorrectAnswersByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetIncorrectAnswersByCategoryIdAsync(request.CategoryId, cancellationToken);
    }
}