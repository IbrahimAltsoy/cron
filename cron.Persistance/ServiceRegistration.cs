using cron.Application.Repositories;
using cron.Application.Repositories.Blog;
using cron.Persistance.Context;
using cron.Persistance.Repositories;
using cron.Persistance.Repositories.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace cron.Persistance
{
    public static class ServiceREgistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<CronAppDbContext>(options => options.UseSqlServer(Configiration.ConnectingString));

            services.AddScoped<IBlogReadRepository, BlogReadRepository>();
            services.AddScoped<IBlogWriteRepository, BlogWriteRepository>();
        }
        
    }
}
