using cron.Application.Repositories.Blog;
using cron.Persistance.Context;
using b=cron.Domain.Entities;

namespace cron.Persistance.Repositories.Blog
{
    public class BlogReadRepository : ReadRepository<b.Blog>, IBlogReadRepository
    {
        public BlogReadRepository(CronAppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
