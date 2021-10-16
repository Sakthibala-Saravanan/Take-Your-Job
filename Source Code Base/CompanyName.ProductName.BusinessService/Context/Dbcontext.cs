using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AspireSystems.Service.Context;
using AspireSystems.Infrastructure.Helpers;

namespace AspireSystems.TakeYourJob.BusinessService.Context
{
    public partial class Dbcontext : BaseContext, IContext
    {

        public Dbcontext(DbContextOptions<Dbcontext> options) : base(ContextHelper.ChangeOptionsType<BaseContext> (options))
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.DisplayName();
            }
            base.OnModelCreating(modelBuilder);

        }
    }
}


