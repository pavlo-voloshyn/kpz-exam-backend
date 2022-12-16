using AutoMapper;
using R.DAL.Models;
using R.WebApi.ViewModels;

namespace R.WebApi.MapperProfiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateInsert>().ReverseMap();
            CreateMap<Candidate, CandidateUpdate>().ReverseMap();
            CreateMap<Candidate, CandidateView>().ReverseMap();
            CreateMap<Candidate, Candidate>();
        }
    }
}
