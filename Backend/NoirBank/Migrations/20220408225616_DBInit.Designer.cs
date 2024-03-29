﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoirBank;

namespace NoirBank.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220408225616_DBInit")]
    partial class DBInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NoirBank.Data.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccountId");

                    b.HasIndex("CustomerID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.Card", b =>
                {
                    b.Property<Guid>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ExpirationDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("CardID");

                    b.HasIndex("AccountID");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.Operation", b =>
                {
                    b.Property<Guid>("OperationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("OperationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PreviousBalance")
                        .HasColumnType("float");

                    b.Property<Guid?>("SenderAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranscationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OperationID");

                    b.HasIndex("SenderAccountId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.SessionLog", b =>
                {
                    b.Property<Guid>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LoginDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("SessionID");

                    b.HasIndex("CustomerID");

                    b.ToTable("SessionLogs");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.Account", b =>
                {
                    b.HasOne("NoirBank.Data.Entities.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.Card", b =>
                {
                    b.HasOne("NoirBank.Data.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.Operation", b =>
                {
                    b.HasOne("NoirBank.Data.Entities.Account", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.SessionLog", b =>
                {
                    b.HasOne("NoirBank.Data.Entities.Customer", "Customer")
                        .WithMany("SessionLogs")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("NoirBank.Data.Entities.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("SessionLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
