using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBBase : DbContext
    {
      public DBBase() : base("OnlineStores")
    { }
        public DbSet<DBCategory> dBCategories { get; set; }
        public DbSet<DBDiscount> dBDiscounts { get; set; }
        public DbSet<DBEmployee> dBEmployees { get; set; }
        public DbSet<DBManufacturer> dBManufacturers { get; set; }
        public DbSet<DBPosition> dBPositions { get; set; }
        public DbSet<DBPremises> dBPremises { get; set; }
        public DbSet<DBPremisesType> dBPremisesTypes { get; set; }
        public DbSet<DBProduct> dBProducts { get; set; }
        public DbSet<DBProductAvailability> dBProductAvailabilities { get; set; }
        public DbSet<DBSales> dBSales { get; set; }
    }
}