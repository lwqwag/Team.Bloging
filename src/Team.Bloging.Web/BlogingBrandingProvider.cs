using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Team.Blogging.Web
{
    [Dependency(ReplaceServices = true)]
    public class BlogingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Bloging";
    }
}
