using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Team.Bloging.Web
{
    [Dependency(ReplaceServices = true)]
    public class BlogingBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Bloging";
    }
}
