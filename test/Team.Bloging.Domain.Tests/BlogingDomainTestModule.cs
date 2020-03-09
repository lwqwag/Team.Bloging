using Team.Blogging.MongoDb;
using Volo.Abp.Modularity;

namespace Team.Blogging
{
    [DependsOn(
        typeof(BloggingMongoDbTestModule)
        )]
    public class BlogingDomainTestModule : AbpModule
    {

    }
}