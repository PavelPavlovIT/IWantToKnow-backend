using IWantKnowNet.Data.Repositories.Categories;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Queries.GetCategoryByParentId;

public class GetCategoryByParentIdHandler(ICategoryRepository? repository) : IRequestHandler<GetCategoryByParentIdQuery, List<CategoryViewModel>?>
{
    public async Task<List<CategoryViewModel>?> Handle(GetCategoryByParentIdQuery request,
        CancellationToken cancellationToken)
    {
        return await repository?.GetChildrenOfCategoryAsync(request.User, request.ParentId, cancellationToken)!;
    }
}