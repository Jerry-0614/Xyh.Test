using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Xyh.Portal.EntityFrameworkCore
{
    [DependsOn(
        typeof(PortalCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class PortalEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalEntityFrameworkCoreModule).GetAssembly());
        }
    }
}