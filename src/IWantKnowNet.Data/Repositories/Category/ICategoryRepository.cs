using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace IWantKnowNet.Data.Repositories.Categories;

public interface ICategoryRepository
{
    Task<List<string>?> GetAllIdCategoryByParentIdAsync(string parentId, CancellationToken cancellationToken);
    Task<List<CategoryViewModel>> GetHierarchyCategory(string lang, string categoryId, CancellationToken cancellationToken);
    Task<string> GetHierarchyCategoryAsString(string lang, string categoryId, CancellationToken cancellationToken);
    Task<List<CategoryViewModel>?> GetChildrenOfCategoryAsync(ApplicationUser? user, string? parentId, CancellationToken cancellationToken);
    Task<CategoryViewModel?> GetCategoryByCategoryIdAsync(string lang, string categoryId, CancellationToken cancellationToken);
    Task AddCategoryAsync(CategoryViewModel model, CancellationToken cancellationToken);
    Task UpdateCategoryAsync(CategoryViewModel model, CancellationToken cancellationToken);
    Task RemoveCategoryAsync(CategoryViewModel model, CancellationToken cancellationToken);
}