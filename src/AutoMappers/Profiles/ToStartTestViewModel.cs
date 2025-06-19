using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;
using Services.TestService.Commands;
using Services.TestService.Commands.StartTest;

namespace AutoMappers.Profiles;

public class ToStartTestViewModel : Profile
{
    public ToStartTestViewModel()
    {
        CreateMap<StartTestViewModel, Test>();
    }
}