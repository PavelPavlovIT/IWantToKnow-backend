using IWantKnowNet.Data.Repositories.Categories;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Queries.GetHierarchyCategory;

public class GetHierarchyCategoryHandler() : IRequestHandler<GetHierarchyCategoryQuery, IList<CategoryViewModel>?>
{
    private readonly ICategoryRepository? _repository;

    public GetHierarchyCategoryHandler(ICategoryRepository? repository) : this()
    {
        _repository = repository;
    }

    public async Task<IList<CategoryViewModel>?> Handle(GetHierarchyCategoryQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository!.GetHierarchyCategory(request.Lang, request.CategoryId, cancellationToken);
    }
}