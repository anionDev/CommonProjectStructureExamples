using Microsoft.EntityFrameworkCore;
using GRYLibrary.Core.APIServer.CommonDBTypes;
using DotNetWebAPICodeUnit.Core.Database.Contexts.DataTypes;

namespace DotNetWebAPICodeUnit.Core.Database.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<KeyValuePair> Properties { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
