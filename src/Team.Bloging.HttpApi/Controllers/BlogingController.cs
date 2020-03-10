using Team.Blogging.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Team.Blogging.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BlogingController : AbpController
    {
        protected BlogingController()
        {
            LocalizationResource = typeof(BloggingResource);
        }
    }
}