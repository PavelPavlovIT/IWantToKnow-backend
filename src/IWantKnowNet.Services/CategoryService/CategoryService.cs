using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Responses;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.CategoryService.Commands.AddCategory;
using Services.CategoryService.Commands.RemoveCategory;
using Services.CategoryService.Commands.UpdateCategory;
using Services.CategoryService.Queries.GetCategoryByCategoryId;
using Services.CategoryService.Queries.GetCategoryByParentId;
using Services.CategoryService.Queries.GetHierarchyCategory;

namespace Services.CategoryService;

public class CategoryService(
    ILogger<CategoryService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), ICategoryService
{
    public async Task<ResponseQuery<CategoryViewModel>> GetHierarchyCategory(
        string lang,
        string? categoryId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetHierarchyCategory failed";

        try
        {
            IList<CategoryViewModel>? items;
            if (string.IsNullOrEmpty(categoryId) || categoryId.Equals("undefined"))
            {
                items =
                [
                    new CategoryViewModel(
                        Guid.Empty.ToString(),
                        false,
                        false,
                        string.Empty,
                        string.Empty,
                        "Root",
                        "Root",
                        "Root",
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        0,
                        -1)
                ];
                return new ResponseQuery<CategoryViewModel>(true, "Executed GetHierarchyCategory successfully",
                    items);
            }

            items = await Mediator.Send(new GetHierarchyCategoryQuery { Lang = lang, CategoryId = categoryId },
                cancellationToken);
            return new ResponseQuery<CategoryViewModel>(true, "Executed GetHierarchyCategory successfully",
                items);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseQuery<CategoryViewModel>(false, errMessage);
        }
    }

    public async Task<ResponseQuery<CategoryViewModel>?> GetCategoryByParentIdAsync(
        ApplicationUser? user,
        string? parentId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetCategoryByParentIdAsync failed";

        try
        {
            var lang = user?.Language ?? "en";
            var userId = user?.Id;
            var result = await Mediator.Send(new GetCategoryByParentIdQuery
            {
                User = user,
                ParentId = parentId
            }, cancellationToken);

            return new ResponseQuery<CategoryViewModel>(true, "Executed GetCategoryByParentIdAsync successfully", result);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return new ResponseQuery<CategoryViewModel>(false, errMessage);
        }
    }


    public async Task<CategoryViewModel?> GetCategoryByCategoryIdAsync(
        string lang,
        string categoryId,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetCategoryByCategoryIdAsync failed";

        try
        {
            return await Mediator.Send(new GetCategoryByCategoryIdQuery { Lang = lang, CategoryId = categoryId },
                cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task UpdateCategoryAsync(
        CategoryViewModel categoryViewModel,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed UpdateCategoryAsync failed";

        try
        {
            await Mediator.Send(new UpdateCategoryQuery { CategoryViewModel = categoryViewModel },
                cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
        }
    }

    public async Task RemoveCategoryAsync(
        CategoryViewModel categoryViewModel,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed RemoveCategoryAsync failed";

        try
        {
            await Mediator.Send(new RemoveCategoryQuery { CategoryViewModel = categoryViewModel }, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
        }
    }

    public async Task AddCategoryAsync(
        CategoryViewModel categoryViewModel,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed AddCategoryAsync failed";

        try
        {
            await Mediator.Send(new AddCategoryQuery { CategoryViewModel = categoryViewModel }, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
        }
    }
}