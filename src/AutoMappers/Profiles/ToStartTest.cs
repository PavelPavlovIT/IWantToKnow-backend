using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace AutoMappers.Profiles;

public class ToStartTest : Profile
{
    public ToStartTest()
    {
        CreateMap<Test, StartTestViewModel>();
    }
}