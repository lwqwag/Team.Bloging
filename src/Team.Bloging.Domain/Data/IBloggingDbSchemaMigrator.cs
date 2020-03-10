using System.Threading.Tasks;

namespace Team.Blogging.Data
{
    public interface IBloggingDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
