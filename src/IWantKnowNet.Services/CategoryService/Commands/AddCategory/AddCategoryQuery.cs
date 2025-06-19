using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Commands.AddCategory;

public class AddCategoryQuery : IRequest
{
    public required CategoryViewModel CategoryViewModel { get; init; }
}