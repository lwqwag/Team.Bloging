using Team.Blogging.MongoDb;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Team.Blogging.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BlogingMongoDbModule),
        typeof(BloggingApplicationContractsModule)
        )]
    public class BloggingDbMigratorModule : AbpModule
    {
        
    }
}
