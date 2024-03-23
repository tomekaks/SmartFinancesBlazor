﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartFinances.Infrastructure.DataBase;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240323154355_RemoveRelationBetweenAccountAndYearlySummary")]
    partial class RemoveRelationBetweenAccountAndYearlySummary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                            ConcurrencyStamp = "a628b2e9-bcfd-49a9-8e7b-b2bcc30b7bed",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                            ConcurrencyStamp = "d30155d4-67c5-4999-9047-0888d3c8515a",
                            Name = "TestUser",
                            NormalizedName = "TESTUSER"
                        },
                        new
                        {
                            Id = "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                            ConcurrencyStamp = "9a2df1f0-8b8c-465b-bf9b-7e1b3fd8de82",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                            RoleId = "abebd04b-4c91-40ca-a99e-8577ff0f262e"
                        },
                        new
                        {
                            UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                            RoleId = "dea03c83-9eae-4ce3-9560-7b3aec0f1b00"
                        },
                        new
                        {
                            UserId = "8f095269-a72b-4427-bcaf-d860249770c9",
                            RoleId = "dea03c83-9eae-4ce3-9560-7b3aec0f1b00"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Budget")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Balance = 2000m,
                            Budget = 0m,
                            Number = "11AAAA111111",
                            Type = 1,
                            UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee"
                        },
                        new
                        {
                            Id = -2,
                            Balance = 2000m,
                            Budget = 0m,
                            Number = "22BBBB222222",
                            Type = 1,
                            UserId = "8f095269-a72b-4427-bcaf-d860249770c9"
                        },
                        new
                        {
                            Id = -3,
                            Balance = 2000m,
                            Budget = 0m,
                            Number = "33CCCC333333",
                            Type = 2,
                            UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee"
                        },
                        new
                        {
                            Id = -4,
                            Balance = 2000m,
                            Budget = 0m,
                            Number = "44DDDD444444",
                            Type = 3,
                            UserId = "8f095269-a72b-4427-bcaf-d860249770c9"
                        });
                });

            modelBuilder.Entity("SmartFinances.Core.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSuspended")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("NumberOfAccounts")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuspensionReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7f56edea-0dac-4e6f-86c9-f488be5a33cc",
                            Email = "admin@email.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            IsSuspended = false,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            NumberOfAccounts = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAEDdSvzw3/ko5VKQoMUGBXD5g8MLFmVFh6OOXG8wPT/48FS6wIqEZvKOXsad6VKqAkg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5fcb40e7-28cb-4ee4-a8a9-0284266510cc",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "26f192da-ebf0-4c51-8a4d-9678d6b44c4a",
                            Email = "sarahconor@skynet.com",
                            EmailConfirmed = true,
                            FirstName = "Sarah",
                            IsSuspended = false,
                            LastName = "Connor",
                            LockoutEnabled = false,
                            NormalizedEmail = "SARAHCONNOR@SKYNET.COM",
                            NormalizedUserName = "ILIKEROBOTS",
                            NumberOfAccounts = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAELXxaYgrelZLibHvfC+rH1CIfh6NYsCy5/CEDTwZzqE8m7UtHG1xXl1oWfg1qkI3/g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2bcd19b6-573b-4845-8b25-ea544773fc4e",
                            TwoFactorEnabled = false,
                            UserName = "ILikeRobots"
                        },
                        new
                        {
                            Id = "8f095269-a72b-4427-bcaf-d860249770c9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6bba9a48-a935-42c6-a3e4-cb2a28eef117",
                            Email = "tylerdurden@fightclub.com",
                            EmailConfirmed = true,
                            FirstName = "Tyler",
                            IsSuspended = false,
                            LastName = "Durden",
                            LockoutEnabled = false,
                            NormalizedEmail = "TYLERDURDEN@FIGHTCLUB.COM",
                            NormalizedUserName = "FIRSTRULE",
                            NumberOfAccounts = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAEDwUMbYY1grmG3TO/SW1B86q1FkyO+SDSNe4uZs6/sBCZMIBIsBYn0/tF0910Jf6GQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e90c2c52-1bdd-4eaf-8254-2c410ef94463",
                            TwoFactorEnabled = false,
                            UserName = "FirstRule"
                        });
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExpenseTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MonthlySummaryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseTypeId");

                    b.HasIndex("MonthlySummaryId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ExpenseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Housing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Utilities"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Clothes"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Health"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Personal"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Household"
                        });
                });

            modelBuilder.Entity("SmartFinances.Core.Data.MonthlySummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AmountSaved")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountSpent")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Budget")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("YearlySummaryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YearlySummaryId");

                    b.ToTable("MonthlySummaries");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.RegularExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExpenseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionalAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ExpenseTypeId");

                    b.HasIndex("TransactionalAccountId");

                    b.ToTable("RegularExpenses");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.SavingsAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Goal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SavingsAccounts");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.TransactionalAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Budget")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TransactionalAccounts");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Balance = 2000m,
                            Budget = 0m,
                            CreationDateTime = new DateTime(2024, 3, 23, 15, 43, 55, 490, DateTimeKind.Utc).AddTicks(1384),
                            Name = "ILikeRobots",
                            Number = "11AAAA111111",
                            Type = 1,
                            UserId = "9ef201b2-999c-4161-8f2b-d7994971e5ee"
                        },
                        new
                        {
                            Id = -2,
                            Balance = 2000m,
                            Budget = 0m,
                            CreationDateTime = new DateTime(2024, 3, 23, 15, 43, 55, 490, DateTimeKind.Utc).AddTicks(1386),
                            Name = "FirstRule",
                            Number = "22BBBB222222",
                            Type = 1,
                            UserId = "8f095269-a72b-4427-bcaf-d860249770c9"
                        });
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReceiverAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<string>("ReceiverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.YearlySummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AmountSaved")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountSpent")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Budget")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TransactionalAccountId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionalAccountId");

                    b.ToTable("YearlySummaries");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Account", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Contact", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Expense", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ExpenseType", "ExpenseType")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartFinances.Core.Data.MonthlySummary", "MonthlySummary")
                        .WithMany("Expenses")
                        .HasForeignKey("MonthlySummaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExpenseType");

                    b.Navigation("MonthlySummary");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.MonthlySummary", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.YearlySummary", "YearlySummary")
                        .WithMany("MonthlySummaries")
                        .HasForeignKey("YearlySummaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YearlySummary");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.RegularExpense", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.Account", "Account")
                        .WithMany("RegularExpenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SmartFinances.Core.Data.ExpenseType", "ExpenseType")
                        .WithMany("RegularExpenses")
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartFinances.Core.Data.TransactionalAccount", "TransactionalAccount")
                        .WithMany("RegularExpenses")
                        .HasForeignKey("TransactionalAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ExpenseType");

                    b.Navigation("TransactionalAccount");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.SavingsAccount", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", "User")
                        .WithOne("SavingsAccount")
                        .HasForeignKey("SmartFinances.Core.Data.SavingsAccount", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.TransactionalAccount", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", "User")
                        .WithMany("TransactionalAccounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.YearlySummary", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.TransactionalAccount", "TransactionalAccount")
                        .WithMany("YearlySummaries")
                        .HasForeignKey("TransactionalAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TransactionalAccount");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Account", b =>
                {
                    b.Navigation("RegularExpenses");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.ApplicationUser", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Contacts");

                    b.Navigation("SavingsAccount");

                    b.Navigation("TransactionalAccounts");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.ExpenseType", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("RegularExpenses");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.MonthlySummary", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.TransactionalAccount", b =>
                {
                    b.Navigation("RegularExpenses");

                    b.Navigation("YearlySummaries");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.YearlySummary", b =>
                {
                    b.Navigation("MonthlySummaries");
                });
#pragma warning restore 612, 618
        }
    }
}
