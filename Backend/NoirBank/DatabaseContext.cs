
using System;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoirBank.Data.Entities;


namespace NoirBank
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<SessionLog> SessionLogs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
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
            modelBuilder.Entity<User>().ToTable<User>("Users");
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
            {
                b.ToTable("Roles");
            });
            modelBuilder.Entity<IdentityRole<Guid>>(x => x.ToTable("Roles"));
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            base.OnModelCreating(modelBuilder);
        }
    }
}

