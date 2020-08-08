using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Xyh.Portal
{
    [DependsOn(
        typeof(PortalCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PortalApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalApplicationModule).GetAssembly());
        }
    }
}