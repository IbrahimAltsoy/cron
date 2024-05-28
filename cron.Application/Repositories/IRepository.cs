using cron.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace cron.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table { get; }

    }
}
