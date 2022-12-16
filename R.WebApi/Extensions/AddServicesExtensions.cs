using R.BL.Services;
using R.BL.Services.Implementations;

namespace R.WebApi.Extensions
{
    public static class AddServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IInterviewerService, InterviewerService>();
            services.AddTransient<IInterviewService, InterviewService>();
        }
    }
}
