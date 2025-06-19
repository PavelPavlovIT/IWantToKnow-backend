using IWantKnowNet.Data.Repositories.Categories;
using MediatR;

namespace Services.CategoryService.Commands.AddCategory;

public class AddCategoryHandler() : IRequestHandler<AddCategoryQuery>
{
    private readonly ICategoryRepository? _repository;

    public AddCategoryHandler(ICategoryRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task Handle(AddCategoryQuery request, CancellationToken cancellationToken)
    {
        await _repository!.AddCategoryAsync(request.CategoryViewModel, cancellationToken);
    }
}