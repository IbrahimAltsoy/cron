using cron.Domain.Entities.Common;
using System.Linq.Expressions;

namespace cron.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync(bool tracking);
        Task<T> GetByIdAsync(string id, bool tracking);
    }
}
