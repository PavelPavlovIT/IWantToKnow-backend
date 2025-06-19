using AutoMapper;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.ViewModels;

namespace AutoMappers.Profiles;

public class ToQuestionViewModel : Profile
{
    public ToQuestionViewModel()
    {
        CreateMap<QuestionViewModel, Question>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.QuestionId));
        CreateMap<QuestionViewModel, RandomQuestionViewModel>();
        CreateMap<QuestionViewModel, StudyQuestion>();
    }
}