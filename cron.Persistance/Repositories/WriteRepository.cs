using cron.Application.Repositories;
using cron.Domain.Entities.Common;
using cron.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace cron.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        readonly CronAppDbContext _dbcontext;

        public WriteRepository(CronAppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public DbSet<T> Table => _dbcontext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }
        public async Task<int> SaveChangesAsync()
        {

            return await _dbcontext.SaveChangesAsync();
        }
    }
}
