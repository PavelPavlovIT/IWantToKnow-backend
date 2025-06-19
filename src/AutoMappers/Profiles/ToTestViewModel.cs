using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace AutoMappers.Profiles;

public class ToTestViewModel : Profile
{
    public ToTestViewModel()
    {
        CreateMap<TestViewModel, Test>();
    }
}