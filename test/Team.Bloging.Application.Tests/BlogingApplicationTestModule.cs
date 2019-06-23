using Volo.Abp.Modularity;

namespace Team.Bloging
{
    [DependsOn(
        typeof(BlogingApplicationModule),
        typeof(BlogingDomainTestModule)
        )]
    public class BlogingApplicationTestModule : AbpModule
    {

    }
}