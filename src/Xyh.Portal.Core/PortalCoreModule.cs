using Abp.Modules;
using Abp.Reflection.Extensions;
using Xyh.Portal.Localization;

namespace Xyh.Portal
{
    public class PortalCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            PortalLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalCoreModule).GetAssembly());
        }
    }
}