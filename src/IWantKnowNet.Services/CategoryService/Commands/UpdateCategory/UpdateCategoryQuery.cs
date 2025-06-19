using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Commands.UpdateCategory;

public class UpdateCategoryQuery : IRequest
{
    public required CategoryViewModel CategoryViewModel { get; init; }
}