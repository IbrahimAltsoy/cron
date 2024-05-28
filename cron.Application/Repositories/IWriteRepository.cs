using cron.Domain.Entities.Common;

namespace cron.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T entity);
       Task<int> SaveChangesAsync();

    }
}
