using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Queries.GetCategoryByParentId;

public class GetCategoryByParentIdQuery : IRequest<List<CategoryViewModel>?>
{
    public string? ParentId { get; init; }
    public ApplicationUser? User { get; init; }
}