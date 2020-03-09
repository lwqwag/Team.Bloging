using Volo.Abp.Modularity;

namespace Team.Blogging
{
    [DependsOn(
        typeof(BlogingApplicationModule),
        typeof(BlogingDomainTestModule)
        )]
    public class BloggingApplicationTestModule : AbpModule
    {

    }
}