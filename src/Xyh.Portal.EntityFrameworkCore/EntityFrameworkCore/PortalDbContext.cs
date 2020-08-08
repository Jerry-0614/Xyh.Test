using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Xyh.Portal.EntityFrameworkCore
{
    public class PortalDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public PortalDbContext(DbContextOptions<PortalDbContext> options) 
            : base(options)
        {

        }
        
    }
}
