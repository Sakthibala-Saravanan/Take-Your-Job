using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Linq;

namespace AspireSystems.Infrastructure.Helpers
{
    public static class ContextHelper
    {
        public static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension);

            if (sqlExt == null)
                throw (new Exception("Failed to retrieve SQL connection string for base Context"));

            return new DbContextOptionsBuilder<T>()
                     .UseSqlServer(((SqlServerOptionsExtension)sqlExt).ConnectionString)
                     .Options;
        }
    }
}
