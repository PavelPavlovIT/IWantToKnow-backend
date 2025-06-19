using IWantKnowNet.Data.Repositories.Categories;
using MediatR;

namespace Services.CategoryService.Commands.RemoveCategory;

public class RemoveCategoryHandler() : IRequestHandler<RemoveCategoryQuery>
{
    private readonly ICategoryRepository? _repository;

    public RemoveCategoryHandler(ICategoryRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCategoryQuery request, CancellationToken cancellationToken)
    {
        await _repository!.RemoveCategoryAsync(request.CategoryViewModel, cancellationToken);
    }
}