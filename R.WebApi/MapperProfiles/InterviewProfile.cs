using AutoMapper;
using R.DAL.Models;
using R.WebApi.ViewModels;

namespace R.WebApi.MapperProfiles
{
    public class InterviewProfile : Profile
    {
        public InterviewProfile()
        {
            CreateMap<Interview, InterviewInsert>().ReverseMap();
            CreateMap<Interview, InterviewUpdate>().ReverseMap();
            CreateMap<Interview, InterviewView>().ReverseMap();
            CreateMap<Interview, Interview>();
        }
    }
}
