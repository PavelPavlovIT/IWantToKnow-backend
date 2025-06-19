using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace AutoMappers.Profiles;

public class ToCorrectAnswerViewModel : Profile
{
    public ToCorrectAnswerViewModel()
    {
        CreateMap<CorrectAnswerViewModel, CorrectAnswer>();
    }
}