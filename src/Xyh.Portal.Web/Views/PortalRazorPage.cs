using Abp.AspNetCore.Mvc.Views;

namespace Xyh.Portal.Web.Views
{
    public abstract class PortalRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected PortalRazorPage()
        {
            LocalizationSourceName = PortalConsts.LocalizationSourceName;
        }
    }
}
