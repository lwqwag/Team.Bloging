using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Team.Bloging.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(BlogingHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BlogingConsoleApiClientModule : AbpModule
    {
        
    }
}
