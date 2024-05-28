using cron.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace cron.Persistance
{
    public static class ServiceREgistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<CronAppDbContext>(options => options.UseSqlServer(Configiration.ConnectingString));
        }
    }
}
