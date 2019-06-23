using Team.Bloging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Team.Bloging.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class BlogingPageModel : AbpPageModel
    {
        protected BlogingPageModel()
        {
            LocalizationResourceType = typeof(BlogingResource);
        }
    }
}