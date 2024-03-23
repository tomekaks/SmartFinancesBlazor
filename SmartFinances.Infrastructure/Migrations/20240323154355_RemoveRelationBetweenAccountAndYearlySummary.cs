using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class RemoveRelationBetweenAccountAndYearlySummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YearlySummaries_Accounts_AccountId",
                table: "YearlySummaries");

            migrationBuilder.DropIndex(
                name: "IX_YearlySummaries_AccountId",
                table: "YearlySummaries");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "YearlySummaries");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "YearlySummaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 22, 10, 58, 7, 765, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 22, 10, 58, 7, 765, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.CreateIndex(
                name: "IX_YearlySummaries_AccountId",
                table: "YearlySummaries",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_YearlySummaries_Accounts_AccountId",
                table: "YearlySummaries",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
