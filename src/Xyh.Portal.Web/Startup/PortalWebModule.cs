using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Xyh.Portal.Configuration;
using Xyh.Portal.EntityFrameworkCore;

namespace Xyh.Portal.Web.Startup
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(
        typeof(PortalApplicationModule), 
        typeof(PortalEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class PortalWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public PortalWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(PortalConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<PortalNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(PortalApplicationModule).GetAssembly()
                );
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalWebModule).GetAssembly());
        }
        /// <summary>
        /// 
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}