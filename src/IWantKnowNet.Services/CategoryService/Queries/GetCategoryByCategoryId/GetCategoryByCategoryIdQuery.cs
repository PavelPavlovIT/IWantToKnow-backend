using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Queries.GetCategoryByCategoryId;

public class GetCategoryByCategoryIdQuery : IRequest<CategoryViewModel?>
{
    public string Lang { get; set; }
    public required string CategoryId { get; init; }
    
}