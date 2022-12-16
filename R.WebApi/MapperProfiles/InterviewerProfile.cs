using AutoMapper;
using R.DAL.Models;
using R.WebApi.ViewModels;

namespace R.WebApi.MapperProfiles
{
    public class InterviewerProfile : Profile
    {
        public InterviewerProfile()
        {
            CreateMap<Interviewer, InterviewerInsert>().ReverseMap();
            CreateMap<Interviewer, InterviewerUpdate>().ReverseMap();
            CreateMap<Interviewer, InterviewerView>().ReverseMap();
            CreateMap<Interviewer, Interviewer>();
        }
    }
}
