using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using cron.Persistance.Context;

namespace cron.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CronAppDbContext>
    {

        public CronAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CronAppDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configiration.ConnectingString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
