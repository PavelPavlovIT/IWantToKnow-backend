using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace AutoMappers.Profiles;

public class ToCorrectAnswer : Profile
{
    public ToCorrectAnswer()
    {
        CreateMap<CorrectAnswer, CorrectAnswerViewModel>();
    }
}