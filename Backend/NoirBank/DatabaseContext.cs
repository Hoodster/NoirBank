
using System;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NoirBank.Data.Entities;
using NoirBank.Data.Enums;
using OperationType = NoirBank.Data.Enums.OperationType;

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
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

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

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType {
                    AccountTypeID = AccountTypesIDs.STANDARD,
                    Type = AccountTypesOptions.STANDARD
                },
                new AccountType {
                    AccountTypeID = AccountTypesIDs.BUSINESS,
                    Type = AccountTypesOptions.BUSINESS
                },
                new AccountType {
                    AccountTypeID = AccountTypesIDs.SAVING,
                    Type = AccountTypesOptions.SAVING
                },
                new AccountType {
                    AccountTypeID = AccountTypesIDs.INVESTMENT,
                    Type = AccountTypesOptions.INVESTMENT
                }
                );

            modelBuilder.Entity<CardType>().HasData(
                new CardType {
                    CardTypeID = CardTypesIDs.DEBIT,
                    Type = CardTypesOptions.DEBIT
                },
                new CardType {
                    CardTypeID = CardTypesIDs.CREDIT,
                    Type = CardTypesOptions.CREDIT
                }
                );

            modelBuilder.Entity<OperationType>().HasData(
                new OperationType {
                    OperationTypeID = OperationTypesIDs.DEPOSIT,
                    Type = OperationTypesOptions.DEPOSIT
                },
                new OperationType {
                    OperationTypeID = OperationTypesIDs.CARD_TRANSACTION,
                    Type = OperationTypesOptions.CARD_TRANSACTION
                },
                new OperationType {
                    OperationTypeID = OperationTypesIDs.TRANSFER,
                    Type = OperationTypesOptions.TRANSFER
                }
                );

            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType {
                    TransactionTypeID = TransactionTypesIDs.INCOME,
                    Type = TransactionTypesOptions.INCOME
                },
                new TransactionType {
                    TransactionTypeID = TransactionTypesIDs.OUTCOME,
                    Type = TransactionTypesOptions.OUTCOME
                }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}

