using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.CategoryService.Commands.RemoveCategory;

public class RemoveCategoryQuery : IRequest
{
    public required CategoryViewModel CategoryViewModel { get; init; }
}