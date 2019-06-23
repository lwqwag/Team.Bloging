using System.Threading.Tasks;

namespace Team.Bloging.Data
{
    public interface IBlogingDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
