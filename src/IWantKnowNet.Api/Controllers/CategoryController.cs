using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryService;

namespace IWantKnowNet.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoryController(
    UserManager<ApplicationUser> userManager,
    ICategoryService categoryService,
    ILogger<CategoryController> logger,
    IConfiguration configuration)
    : ApiBaseController(userManager, configuration)
{
    [HttpGet]
    [Route("GetHierarchyOfCategories")]
    public async Task<ResponseQuery<CategoryViewModel>?> GetHierarchyOfCategories(string? categoryId,
        CancellationToken cancellationToken)
    {
        var result = await categoryService.GetHierarchyCategory(Language, categoryId, CancellationToken.None);
        return result;
    }

    [HttpGet]
    [Route("GetCategoryByCategoryId")]
    public async Task<CategoryViewModel?> GetCategoryByCategoryId(string categoryId,
        CancellationToken cancellationToken)
    {
        return await categoryService.GetCategoryByCategoryIdAsync(Language, categoryId, CancellationToken.None);
    }

    [HttpGet]
    [Route("GetCategoryByParentId")]
    public async Task<ResponseQuery<CategoryViewModel>?> GetCategoryByParentId(string? parentId,
        CancellationToken cancellationToken)
    {
        if (String.IsNullOrEmpty(parentId)) parentId = string.Empty;
        if (parentId.Equals("undefined")) parentId = string.Empty;

        var user = await userManager.GetUserAsync(User);
        return await categoryService.GetCategoryByParentIdAsync(user, parentId, CancellationToken.None);
    }

    [HttpPost]
    [Route("AddCategory")]
    public async Task AddCategory(CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        categoryViewModel.CreaterId = userId;
        await categoryService.AddCategoryAsync(categoryViewModel, CancellationToken.None);
    }

    [HttpPost]
    [Route("UpdateCategory")]
    public async Task UpdateCategory(CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        categoryViewModel.CreaterId = userId;
        await categoryService.UpdateCategoryAsync(categoryViewModel, CancellationToken.None);
    }

    [HttpPost]
    [Route("RemoveCategory")]
    public async Task RemoveCategory(CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
    {
        var userId = userManager.GetUserId(User)!;
        categoryViewModel.CreaterId = userId;
        await categoryService.RemoveCategoryAsync(categoryViewModel, CancellationToken.None);
    }
}