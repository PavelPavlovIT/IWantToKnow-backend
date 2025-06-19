using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Queries.GetHierarchyCategory;

public class GetHierarchyCategoryQuery : IRequest<IList<CategoryViewModel>?>
{
    public string Lang { get; set; }
    public required string CategoryId { get; init; }
}