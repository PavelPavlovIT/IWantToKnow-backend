using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace AutoMappers.Profiles;

public class ToQuestion : Profile
{
    public ToQuestion()
    {
        CreateMap<Question, QuestionViewModel>();
    }
}