using GRYLibrary.Core.APIServer.Utilities;
using System;

namespace DotNetWebAPICodeUnit.Core.Database.Contexts.Context000000.DataTypes
{
    [Obsolete(Tools.ObsoleteDataContextMessage)]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
