using R.WebApi.MapperProfiles;

namespace R.WebApi.Extensions
{
    public static class AddMapperProfilesExtension
    {
        public static void AddMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(config => config.AddProfile<CandidateProfile>());
            services.AddAutoMapper(config => config.AddProfile<InterviewerProfile>());
            services.AddAutoMapper(config => config.AddProfile<InterviewProfile>());
        }
    }
}
