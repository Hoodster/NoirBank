
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NoirBank.Data.Entities;


namespace NoirBank
{
    public class DatabaseContext : DbContext
    {
        public DbSet<BankAccount> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<SessionLog> SessionLogs { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder
                .Entity<Card>()
                .Property(e => e.CardType)
                .HasConversion<string>();
            modelBuilder
                .Entity<Operation>()
                .Property(e => e.TranscationType)
                .HasConversion<string>();
            modelBuilder
                .Entity<Operation>()
                .Property(e => e.OperationType)
                .HasConversion<string>();
            modelBuilder
                .Entity<BankAccount>()
                .Property(e => e.AccountType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}

