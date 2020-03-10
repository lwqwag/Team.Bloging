using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;
using Volo.Blogging;

namespace Team.Blogging
{
    [DependsOn(
        typeof(BloggingApplicationContractsModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule)
        )]
    [DependsOn(typeof(BloggingHttpApiModule))]
    public class BlogingHttpApiModule : AbpModule
    {
        
    }
}
