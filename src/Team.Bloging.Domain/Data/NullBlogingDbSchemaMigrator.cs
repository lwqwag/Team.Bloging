using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Team.Blogging.Data
{
    /* This is used if database provider does't define
     * IBlogingDbSchemaMigrator implementation.
     */
    public class NullBlogingDbSchemaMigrator : IBlogingDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}