using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace Team.Blogging
{
    [DependsOn(
        typeof(BloggingDomainSharedModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule)
    )]
    [DependsOn(typeof(Volo.Blogging.BloggingApplicationContractsModule))]
    public class BloggingApplicationContractsModule : AbpModule
    {

    }
}
