using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace AutoMappers.Profiles;

public class ToTest : Profile
{
    public ToTest()
    {
        CreateMap<Test, TestViewModel>();
    }
}