using System;
using System.Collections.Generic;
using System.Text;
using Team.Blogging.Localization;
using Volo.Abp.Application.Services;

namespace Team.Blogging
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
