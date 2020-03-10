using Team.Blogging.Localization;
using Volo.Abp.Application.Services;

namespace Team.Blogging
{
    /* Inherit your application services from this class.
     */
    public abstract class BloggingAppService : ApplicationService
    {
        protected BloggingAppService()
        {
            LocalizationResource = typeof(BloggingResource);
        }
    }
}
