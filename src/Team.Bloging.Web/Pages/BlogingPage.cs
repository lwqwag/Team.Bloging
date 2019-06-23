using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Team.Bloging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Team.Bloging.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Team.Bloging.Web.Pages.BlogingPage
     */
    public abstract class BlogingPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<BlogingResource> L { get; set; }
    }
}
