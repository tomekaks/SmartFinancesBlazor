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
    [Migration("20231028125459_SeedMoreAccounts")]
    partial class SeedMoreAccounts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
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
                            ConcurrencyStamp = "5e28ea23-b28f-4910-abe3-7c65463d93c3",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                            ConcurrencyStamp = "6d7f4618-4b62-4e1c-b091-7c58f267d22e",
                            Name = "TestUser",
                            NormalizedName = "TESTUSER"
                        },
                        new
                        {
                            Id = "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                            ConcurrencyStamp = "4e65cc54-6a89-4531-9692-3f951223fa57",
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
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
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
                            ConcurrencyStamp = "b6b9fcb9-1a6d-4a19-8114-0d29a9c3e1d9",
                            Email = "admin@email.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            IsSuspended = false,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            NumberOfAccounts = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAEFRIAkFYI6LQPMClkXwLejIFuMIfa3KEINjPxa5olTjrjxKO4z4r/UbMt8/+ijX8JQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "aaec16bd-6053-4b97-901f-77d0c5c25094",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "182a75fa-1cc0-4a8d-b024-940fe81ff72f",
                            Email = "sarahconor@skynet.com",
                            EmailConfirmed = true,
                            FirstName = "Sarah",
                            IsSuspended = false,
                            LastName = "Connor",
                            LockoutEnabled = false,
                            NormalizedEmail = "SARAHCONNOR@SKYNET.COM",
                            NormalizedUserName = "ILIKEROBOTS",
                            NumberOfAccounts = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAEKXw8VyV6GEhPy8AyTc5aP+FdFTFGXZe9mNKG3QVpf0KP/gk4Wcn5lFQ/zcdUbv7Hg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f2abdcfd-d8de-4c33-a9b4-454d06d65bca",
                            TwoFactorEnabled = false,
                            UserName = "ILikeRobots"
                        },
                        new
                        {
                            Id = "8f095269-a72b-4427-bcaf-d860249770c9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e6109c1e-3514-496e-bd82-3695953627bb",
                            Email = "tylerdurden@fightclub.com",
                            EmailConfirmed = true,
                            FirstName = "Tyler",
                            IsSuspended = false,
                            LastName = "Durden",
                            LockoutEnabled = false,
                            NormalizedEmail = "TYLERDURDEN@FIGHTCLUB.COM",
                            NormalizedUserName = "FIRSTRULE",
                            NumberOfAccounts = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAEIC9EMxB3NWprqPHT4kUE/b43+Lu24uuBngGNVo+4PE97hz8kW1hCtSVACfwAwFTqQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9527b3e6-f36b-4a16-903c-c0eadef42ed1",
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

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExpenseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ExpenseTypeId");

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

            modelBuilder.Entity("SmartFinances.Core.Data.RegularExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ExpenseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ExpenseTypeId");

                    b.ToTable("RegularExpenses");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
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

                    b.HasIndex("AccountId");

                    b.ToTable("Transfers");
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
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Contact", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.ApplicationUser", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Expense", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.Account", "Account")
                        .WithMany("Expenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartFinances.Core.Data.ExpenseType", "ExpenseType")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ExpenseType");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.RegularExpense", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.Account", "Account")
                        .WithMany("RegularExpenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartFinances.Core.Data.ExpenseType", "ExpenseType")
                        .WithMany("RegularExpenses")
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("ExpenseType");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Transfer", b =>
                {
                    b.HasOne("SmartFinances.Core.Data.Account", null)
                        .WithMany("Transfers")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.Account", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("RegularExpenses");

                    b.Navigation("Transfers");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.ApplicationUser", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("SmartFinances.Core.Data.ExpenseType", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("RegularExpenses");
                });
#pragma warning restore 612, 618
        }
    }
}
