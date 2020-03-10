using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Team.Blogging.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(BlogingHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BloggingConsoleApiClientModule : AbpModule
    {
        
    }
}
