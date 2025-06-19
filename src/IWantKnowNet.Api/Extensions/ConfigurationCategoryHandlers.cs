using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Services.CategoryService.Commands.AddCategory;
using Services.CategoryService.Commands.RemoveCategory;
using Services.CategoryService.Commands.UpdateCategory;
using Services.CategoryService.Queries.GetCategoryByCategoryId;
using Services.CategoryService.Queries.GetCategoryByParentId;
using Services.CategoryService.Queries.GetHierarchyCategory;

namespace IWantKnowNet.Api.Extensions;

public static class ConfigurationCategoryHandlers
{
    public static IServiceCollection AddCategoryHandlers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IRequestHandler<GetHierarchyCategoryQuery, IList<CategoryViewModel>?>,
                GetHierarchyCategoryHandler>()
            .AddTransient<IRequestHandler<GetCategoryByCategoryIdQuery, CategoryViewModel?>,
                GetCategoryByCategoryIdHandler>()
            .AddTransient<IRequestHandler<GetCategoryByParentIdQuery, List<CategoryViewModel>?>,
                GetCategoryByParentIdHandler>()
            .AddTransient<IRequestHandler<AddCategoryQuery>, AddCategoryHandler>()
            .AddTransient<IRequestHandler<RemoveCategoryQuery>, RemoveCategoryHandler>()
            .AddTransient<IRequestHandler<UpdateCategoryQuery>, UpdateCategoryHandler>();
    }
}