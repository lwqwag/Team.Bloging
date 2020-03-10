using Volo.Abp.Modularity;

namespace Team.Blogging
{
    [DependsOn(
        typeof(BloggingApplicationModule),
        typeof(BlogingDomainTestModule)
        )]
    public class BloggingApplicationTestModule : AbpModule
    {

    }
}