using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;

namespace Services.CategoryService;

public interface ICategoryService
{
    Task<ResponseQuery<CategoryViewModel>> GetHierarchyCategory(string lang, string? categoryId, CancellationToken cancellationToken);
    Task<CategoryViewModel?> GetCategoryByCategoryIdAsync(string lang,string categoryId, CancellationToken cancellationToken);
    Task<ResponseQuery<CategoryViewModel>?> GetCategoryByParentIdAsync(ApplicationUser? user, string? parentId, CancellationToken cancellationToken);

    Task UpdateCategoryAsync(CategoryViewModel categoryViewModel, CancellationToken cancellationToken);
    Task RemoveCategoryAsync(CategoryViewModel categoryViewModel, CancellationToken cancellationToken);
    Task AddCategoryAsync(CategoryViewModel categoryViewModel, CancellationToken cancellationToken);
}