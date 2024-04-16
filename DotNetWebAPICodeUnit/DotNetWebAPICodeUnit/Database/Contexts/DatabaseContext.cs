using Microsoft.EntityFrameworkCore;
using DotNetWebAPICodeUnit.Core.Database.Contexts.DataTypes;

namespace DotNetWebAPICodeUnit.Core.Database.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
