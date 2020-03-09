using MongoDB.Driver;
using Team.Blogging.Users;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Team.Blogging.MongoDb
{
    [ConnectionStringName("Default")]
    public class BlogingMongoDbContext : AbpMongoDbContext
    {
        public IMongoCollection<AppUser> Users => Collection<AppUser>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.Entity<AppUser>(b =>
            {
                /* Sharing the same "AbpUsers" collection
                 * with the Identity module's IdentityUser class. */
                b.CollectionName = "AbpUsers";
            });
        }
    }
}
