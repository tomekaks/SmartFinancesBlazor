using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class RemovedAllDependenciesOnAccountClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegularExpenses_Accounts_AccountId",
                table: "RegularExpenses");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_RegularExpenses_AccountId",
                table: "RegularExpenses");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "RegularExpenses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "f630ce1a-3095-41dd-bfe7-f035a047e59e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "91e312e4-9574-490f-b23d-7739bd971451");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "84fdcf47-00ae-4677-a4e9-9db229d1e32d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8434396b-1b66-4dc7-92f3-15d9e6bd676b", "AQAAAAEAACcQAAAAEHB58lodCroStPQCwjaY0itRsF9h60r5M1QWjFXVvnonMV87DZsTvAZq3jhhUj8gPQ==", "a1130e2e-577b-44ba-886c-8ca3ce6a5318" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04de0f21-f271-4364-af9e-9304a18deaac", "AQAAAAEAACcQAAAAEJvYD1RxaAeGrwK6bTyv+h0m0xt75ZsE/q9Vtk2bmUhnAs2B7USXO3O+5yzPGZjjzg==", "91135a4d-592d-49c0-b757-d76459f957df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fb6849e-f2a9-4179-a4ef-035d6ff3b778", "AQAAAAEAACcQAAAAEBQt3Z6EJcFnAyvpgLTLvzj0o93mFDHwkRWQ6bCHVA4YP8KYVnSumi69Cu+QfomZEQ==", "40aebbad-d6be-41a4-bc1b-9542a4ec8a88" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 23, 16, 3, 17, 797, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 23, 16, 3, 17, 797, DateTimeKind.Utc).AddTicks(4081));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "RegularExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "Budget", "Number", "Type", "UserId" },
                values: new object[,]
                {
                    { -4, 2000m, 0m, "44DDDD444444", 3, "8f095269-a72b-4427-bcaf-d860249770c9" },
                    { -3, 2000m, 0m, "33CCCC333333", 2, "9ef201b2-999c-4161-8f2b-d7994971e5ee" },
                    { -2, 2000m, 0m, "22BBBB222222", 1, "8f095269-a72b-4427-bcaf-d860249770c9" },
                    { -1, 2000m, 0m, "11AAAA111111", 1, "9ef201b2-999c-4161-8f2b-d7994971e5ee" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "a628b2e9-bcfd-49a9-8e7b-b2bcc30b7bed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "d30155d4-67c5-4999-9047-0888d3c8515a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "9a2df1f0-8b8c-465b-bf9b-7e1b3fd8de82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f56edea-0dac-4e6f-86c9-f488be5a33cc", "AQAAAAEAACcQAAAAEDdSvzw3/ko5VKQoMUGBXD5g8MLFmVFh6OOXG8wPT/48FS6wIqEZvKOXsad6VKqAkg==", "5fcb40e7-28cb-4ee4-a8a9-0284266510cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bba9a48-a935-42c6-a3e4-cb2a28eef117", "AQAAAAEAACcQAAAAEDwUMbYY1grmG3TO/SW1B86q1FkyO+SDSNe4uZs6/sBCZMIBIsBYn0/tF0910Jf6GQ==", "e90c2c52-1bdd-4eaf-8254-2c410ef94463" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26f192da-ebf0-4c51-8a4d-9678d6b44c4a", "AQAAAAEAACcQAAAAELXxaYgrelZLibHvfC+rH1CIfh6NYsCy5/CEDTwZzqE8m7UtHG1xXl1oWfg1qkI3/g==", "2bcd19b6-573b-4845-8b25-ea544773fc4e" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 23, 15, 43, 55, 490, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 23, 15, 43, 55, 490, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.CreateIndex(
                name: "IX_RegularExpenses_AccountId",
                table: "RegularExpenses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegularExpenses_Accounts_AccountId",
                table: "RegularExpenses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
