using cron.Application.Repositories;
using cron.Domain.Entities.Common;
using cron.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace cron.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        readonly CronAppDbContext _dbcontext;
        public ReadRepository(CronAppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public DbSet<T> Table => _dbcontext.Set<T>();

        public async Task<List<T>> GetAllAsync(bool tracking)
        {
            IQueryable<T> query = Table;
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }
    }
}
