using cron.Application.Repositories.Blog;
using cron.Persistance.Context;
using b=cron.Domain.Entities;

namespace cron.Persistance.Repositories.Blog
{
    public class BlogWriteRepository : WriteRepository<b.Blog>, IBlogWriteRepository
    {
        public BlogWriteRepository(CronAppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
