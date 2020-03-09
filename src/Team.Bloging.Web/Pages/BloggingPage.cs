using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Team.Blogging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Team.Blogging.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Team.Bloging.Web.Pages.BloggingPage
     */
    public abstract class BloggingPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<BlogingResource> L { get; set; }
    }
}
