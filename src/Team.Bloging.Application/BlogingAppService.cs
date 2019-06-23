using System;
using System.Collections.Generic;
using System.Text;
using Team.Bloging.Localization;
using Volo.Abp.Application.Services;

namespace Team.Bloging
{
    /* Inherit your application services from this class.
     */
    public abstract class BlogingAppService : ApplicationService
    {
        protected BlogingAppService()
        {
            LocalizationResource = typeof(BlogingResource);
        }
    }
}
