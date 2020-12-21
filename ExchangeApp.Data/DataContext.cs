using ExchangeApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApp.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        { }

        public DataContext(DbContextOptions options)
          : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiTestData");
            }
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
