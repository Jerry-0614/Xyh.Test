using Microsoft.EntityFrameworkCore;

namespace Xyh.Portal.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<PortalDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for MwDbContext */
            dbContextOptions.UseSqlServer(connectionString, b => b.UseRowNumberForPaging());
        }
    }
}
