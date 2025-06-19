using IWantKnowNet.Data.Repositories.Categories;
using MediatR;

namespace Services.CategoryService.Commands.UpdateCategory;

public class UpdateCategoryHandler() : IRequestHandler<UpdateCategoryQuery>
{
    private readonly ICategoryRepository? _repository;

    public UpdateCategoryHandler(ICategoryRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCategoryQuery request, CancellationToken cancellationToken)
    {
        await _repository!.UpdateCategoryAsync(request.CategoryViewModel, cancellationToken);
    }
}