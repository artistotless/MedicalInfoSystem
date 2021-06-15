using System.Data.Entity;


namespace MedicalTrader
{
    class DBWrapper : DbContext
    {

        public DbSet<Document> Documents { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<GrlsDrug> GrlpDrugs { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<FarmGroup> FarmGroups { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RegistryCounterfeit> RegistryCounterfeits { get; set; }
        public DbSet<Counterfeit> Counterfeits { get; set; }


        public DBWrapper() : base("DefaultConnection")
        {
        }

    }
}
