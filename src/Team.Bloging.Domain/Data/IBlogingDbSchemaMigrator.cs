using System.Threading.Tasks;

namespace Team.Blogging.Data
{
    public interface IBlogingDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
