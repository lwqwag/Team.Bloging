using Team.Bloging.MongoDb;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Team.Bloging.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BlogingMongoDbModule),
        typeof(BlogingApplicationContractsModule)
        )]
    public class BlogingDbMigratorModule : AbpModule
    {
        
    }
}
