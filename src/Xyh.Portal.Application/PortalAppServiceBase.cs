﻿using Abp.Application.Services;

namespace Xyh.Portal
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class PortalAppServiceBase : ApplicationService
    {
        protected PortalAppServiceBase()
        {
            LocalizationSourceName = PortalConsts.LocalizationSourceName;
        }
    }
}