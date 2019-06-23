using Team.Bloging.MongoDb;
using Volo.Abp.Modularity;

namespace Team.Bloging
{
    [DependsOn(
        typeof(BlogingMongoDbTestModule)
        )]
    public class BlogingDomainTestModule : AbpModule
    {

    }
}