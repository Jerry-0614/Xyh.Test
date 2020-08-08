using Abp.AspNetCore.Mvc.Controllers;

namespace Xyh.Portal.Web.Controllers
{
    public abstract class PortalControllerBase: AbpController
    {
        protected PortalControllerBase()
        {
            LocalizationSourceName = PortalConsts.LocalizationSourceName;
        }
    }
}