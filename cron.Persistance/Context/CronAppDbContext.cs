using cron.Domain.Entities;
using cron.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace cron.Persistance.Context
{
    public class CronAppDbContext:DbContext
    {
        public CronAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {


        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {            
            var values = ChangeTracker.Entries<BaseEntity>();
            foreach (var value in values)
            {
                _ = value.State switch
                {
                    EntityState.Added => value.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => value.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
