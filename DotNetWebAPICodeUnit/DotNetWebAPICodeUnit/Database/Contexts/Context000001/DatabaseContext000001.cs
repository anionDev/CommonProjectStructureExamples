using Microsoft.EntityFrameworkCore;
using DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001.DataTypes;
using GRYLibrary.Core.APIServer.CommonDBTypes;

namespace DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001
{
    public class DatabaseContext000001 : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<KeyValuePair> Properties { get; set; }
        public DatabaseContext000001(DbContextOptions<DatabaseContext000001> options) : base(options)
        {
        }
    }
}
