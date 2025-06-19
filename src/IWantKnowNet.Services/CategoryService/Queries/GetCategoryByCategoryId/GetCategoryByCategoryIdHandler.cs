using IWantKnowNet.Data.Repositories.Categories;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Queries.GetCategoryByCategoryId;

public class GetCategoryByCategoryIdHandler() : IRequestHandler<GetCategoryByCategoryIdQuery, CategoryViewModel?>
{
    private readonly ICategoryRepository? _repository;

    public GetCategoryByCategoryIdHandler(ICategoryRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<CategoryViewModel?> Handle(GetCategoryByCategoryIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetCategoryByCategoryIdAsync(request.Lang, request.CategoryId, cancellationToken);
    }
}