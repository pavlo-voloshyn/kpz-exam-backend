using Microsoft.EntityFrameworkCore;
using R.DAL.Contexts;

namespace R.WebApi.Extensions
{
    public static class AddDbContextsExtension
    {
        public static void AddDbContexts(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("ApplicationDb"));
            });
        }
    }
}
