using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddAccountTypeRelationshipToSavingsAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "SavingsAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SavingsAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, null, "Savings" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "e9ea9cff-70e8-4cd4-bd2d-a2ee4152e841");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "259e85b4-3484-4aa7-9067-18e34cd949b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "39ffecf1-83b2-4b05-938c-ba05fcc995ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d20c1f61-b409-4c2d-ba98-a341b4c5d7b6", "AQAAAAEAACcQAAAAEEd6cCSkQFKyemA1NG6gd0e+ju9Ibubw87nv64x0pS3YNpgXWKtcT/tecormEh+U1w==", "613822bf-b17d-49a4-87f3-cdd16a2c5369" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcbf241a-dcc7-45dd-8505-5fc868b7ab83", "AQAAAAEAACcQAAAAECCKY9a1C3gW11lADEqVJdEiD8wkGljOQ5nrnDdj7gbfjI8JViEI+vjuLMBbeEfxuA==", "b35cd404-2f34-41b2-93e7-cc9c8a1e67c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a40969b-9aa6-42cf-acd1-adbc83bea600", "AQAAAAEAACcQAAAAECI6KfdAZAXyNa1gOwfiAaQ5BA6TsqFyLwytBH3VCHgkcCi/OwuO+asEV8AGXNW5UQ==", "2c7ba86b-fe9b-4b42-a88a-56a75ce1e865" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 9, 13, 39, 3, 972, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 9, 13, 39, 3, 972, DateTimeKind.Utc).AddTicks(3482));

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccounts_AccountTypeId",
                table: "SavingsAccounts",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavingsAccounts_AccountTypes_AccountTypeId",
                table: "SavingsAccounts",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavingsAccounts_AccountTypes_AccountTypeId",
                table: "SavingsAccounts");

            migrationBuilder.DropIndex(
                name: "IX_SavingsAccounts_AccountTypeId",
                table: "SavingsAccounts");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "SavingsAccounts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SavingsAccounts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "18384d78-f3ba-4883-b7cf-1e4ff1704b14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "79e8a294-6852-4109-999d-8a845f0f8482");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "cd153979-9a80-4827-8d73-194d1b6b773a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db7b65b3-6d9a-41f6-9903-6d2e463d428d", "AQAAAAEAACcQAAAAEPhVxBRAWs1SJwc/lXxEZJhxLJo4C+sQ83cYs1TytdPQ3lDgzXrWUkvDtIQXaGPCfQ==", "60c9b22c-6a63-49e6-a273-9ef5e3757831" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b163635a-be0f-4497-9df1-067ae7f052f8", "AQAAAAEAACcQAAAAEJoLXWlGcZm703AVX67R2ArOwMU5eZIajLy0RQVELAwHSfLJ/aoRRG4GE4VT92WBNA==", "41670bfe-2562-4b5d-9959-41510cf3c864" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88aa881f-a81f-48ad-b158-fc51775a455b", "AQAAAAEAACcQAAAAEKVEJ5in2ZKFhIXFwfx3lCLw0DgajqCxceXjGritzyURbX75+n23Zcszrr6AesRxDg==", "c963bc96-534e-4389-9c11-0877d402eff9" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 8, 14, 1, 13, 155, DateTimeKind.Utc).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 8, 14, 1, 13, 155, DateTimeKind.Utc).AddTicks(6619));
        }
    }
}
