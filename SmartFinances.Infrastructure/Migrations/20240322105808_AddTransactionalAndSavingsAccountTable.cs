using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddTransactionalAndSavingsAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_RegularExpenses_Accounts_AccountId",
                table: "RegularExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_AccountId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transfers");

            migrationBuilder.AddColumn<int>(
                name: "TransactionalAccountId",
                table: "YearlySummaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionalAccountId",
                table: "RegularExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SavingsAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsAccounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionalAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionalAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionalAccounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "b71b693c-14c9-434c-828f-f35897288667");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "a359d4d8-9310-4d5a-9c0b-4ba89fd478eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "34f839d6-10f3-457d-b178-871b0053b9af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c4ad8ef-6413-43f5-9ea4-1312317427d1", "AQAAAAEAACcQAAAAEFgQYj7TTyYNR2y4x9ODm4ylSVwn+gP//O4HjsV7rXqpFnrOqNQee9qYdA9vZ0bmsQ==", "490f31dc-b6fa-4a9f-aabd-ef5439cb8f05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e7ff2c4-4f56-46ad-914c-594b24f510a9", "AQAAAAEAACcQAAAAEFeQSdCk8VO/uQdQewhD+hIfxqBDfoo8i2GTLtFlvE7BZrbzPdqsfvUWYwTT/LRJzw==", "50617f30-2361-4aef-8f15-254c7639e261" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1700fcf2-a668-4adb-8adf-2393d10ae68d", "AQAAAAEAACcQAAAAEP6Lx3fYqaitOly9/9ezVtw1FastRxNbXRQPaW94gvzBmk/QnVXgcKCIeHsHrdVNGA==", "f419b200-0636-458d-8c64-a357fc9b303a" });

            migrationBuilder.InsertData(
                table: "TransactionalAccounts",
                columns: new[] { "Id", "Balance", "Budget", "CreationDateTime", "Name", "Number", "Type", "UserId" },
                values: new object[,]
                {
                    { -2, 2000m, 0m, new DateTime(2024, 3, 22, 10, 58, 7, 765, DateTimeKind.Utc).AddTicks(3034), "FirstRule", "22BBBB222222", 1, "8f095269-a72b-4427-bcaf-d860249770c9" },
                    { -1, 2000m, 0m, new DateTime(2024, 3, 22, 10, 58, 7, 765, DateTimeKind.Utc).AddTicks(3031), "ILikeRobots", "11AAAA111111", 1, "9ef201b2-999c-4161-8f2b-d7994971e5ee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearlySummaries_TransactionalAccountId",
                table: "YearlySummaries",
                column: "TransactionalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularExpenses_TransactionalAccountId",
                table: "RegularExpenses",
                column: "TransactionalAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccounts_UserId",
                table: "SavingsAccounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionalAccounts_UserId",
                table: "TransactionalAccounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegularExpenses_Accounts_AccountId",
                table: "RegularExpenses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegularExpenses_TransactionalAccounts_TransactionalAccountId",
                table: "RegularExpenses",
                column: "TransactionalAccountId",
                principalTable: "TransactionalAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_YearlySummaries_TransactionalAccounts_TransactionalAccountId",
                table: "YearlySummaries",
                column: "TransactionalAccountId",
                principalTable: "TransactionalAccounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_RegularExpenses_Accounts_AccountId",
                table: "RegularExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_RegularExpenses_TransactionalAccounts_TransactionalAccountId",
                table: "RegularExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_YearlySummaries_TransactionalAccounts_TransactionalAccountId",
                table: "YearlySummaries");

            migrationBuilder.DropTable(
                name: "SavingsAccounts");

            migrationBuilder.DropTable(
                name: "TransactionalAccounts");

            migrationBuilder.DropIndex(
                name: "IX_YearlySummaries_TransactionalAccountId",
                table: "YearlySummaries");

            migrationBuilder.DropIndex(
                name: "IX_RegularExpenses_TransactionalAccountId",
                table: "RegularExpenses");

            migrationBuilder.DropColumn(
                name: "TransactionalAccountId",
                table: "YearlySummaries");

            migrationBuilder.DropColumn(
                name: "TransactionalAccountId",
                table: "RegularExpenses");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Transfers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "6e2ddc07-da93-4d5e-b34b-8a076a568cdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "38be67b5-6a6d-4209-a11e-757dd02a9177");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "fde9113c-52b7-496a-ad0c-4b1077a77d29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ebd2c48-af2b-482e-88cc-ba071a0c0691", "AQAAAAEAACcQAAAAENx+5GwFuux9EhtmWy+PPYqmcaU5m0qqBxd/A2ZNQ5nfeW5KxdLo1k4BQz16n9fO5A==", "861d6332-c348-4367-ab14-cc585be60a30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc7b4e7c-164e-40ad-9db4-55e390a0ecbe", "AQAAAAEAACcQAAAAEIrcwZkDQFK9tT3G/VUHVB8cL1fCHOfYhJoo3Y9HWsKel29QzUAw45DqX1wCf/JLHw==", "83b58101-62a8-4772-8df7-237b04ce759a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f8773c-7c42-42a1-8563-14d34d8bb305", "AQAAAAEAACcQAAAAEJIzWSV+7JkstFV/Wpzr8nSap2041VNH5KOJw/ZjSgeydZI7NdXVi64XhLzAL+7teg==", "9f429d6f-fcae-472f-8e9b-329477c9e7fb" });

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_AccountId",
                table: "Transfers",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegularExpenses_Accounts_AccountId",
                table: "RegularExpenses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
                table: "Transfers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
