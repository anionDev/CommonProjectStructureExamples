using Microsoft.EntityFrameworkCore;
using DotNetWebAPICodeUnit.Core.Database.Contexts.Context000000.DataTypes;
using GRYLibrary.Core.APIServer.CommonDBTypes;
using System;
using GRYLibrary.Core.APIServer.Utilities;

namespace DotNetWebAPICodeUnit.Core.Database.Contexts.Context000000
{
    [Obsolete(Tools.ObsoleteDataContextMessage)]
    public class DatabaseContext000000 : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<KeyValuePair> Properties { get; set; }
        public DatabaseContext000000(DbContextOptions<DatabaseContext000000> options) : base(options)
        {
        }
    }
}
