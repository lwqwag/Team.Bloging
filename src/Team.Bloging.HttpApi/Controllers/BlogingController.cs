using Team.Bloging.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Team.Bloging.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BlogingController : AbpController
    {
        protected BlogingController()
        {
            LocalizationResource = typeof(BlogingResource);
        }
    }
}