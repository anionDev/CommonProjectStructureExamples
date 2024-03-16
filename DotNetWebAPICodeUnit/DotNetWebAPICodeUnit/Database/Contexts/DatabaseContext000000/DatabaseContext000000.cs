using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using Microsoft.EntityFrameworkCore;
using DotNetWebAPICodeUnit.Core.Database.Contexts.DatabaseContext000000.DataTypes;
using GRYLibrary.Core.APIServer.CommonDBTypes;

namespace DotNetWebAPICodeUnit.Core.Database.Contexts.DatabaseContext000000
{
    public class DatabaseContext000000 : DbContext
    {
        public DbSet<Customer> CurrencyPrices { get; set; }
        public DbSet<KeyValuePair> Properties { get; set; }
        public DatabaseContext000000(IGeneralLogger logger, DbContextOptions<DatabaseContext000000> options) : base(options)
        {
        }
    }
}
