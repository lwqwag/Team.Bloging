using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Blogging;

namespace Team.Blogging
{
    [DependsOn(
        typeof(BloggingDomainModule),
        typeof(BloggingApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        )]
    [DependsOn(typeof(Volo.Blogging.BloggingApplicationModule))]
    public class BloggingApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                /* Use `true` for the `validate` parameter if you want to
                 * validate the profile on application startup.
                 * See http://docs.automapper.org/en/stable/Configuration-validation.html for more info
                 * about the configuration validation. */
                options.AddProfile<BloggingApplicationAutoMapperProfile>();
            });
        }
    }
}
