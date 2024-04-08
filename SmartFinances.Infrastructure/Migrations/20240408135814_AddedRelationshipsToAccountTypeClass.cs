using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddedRelationshipsToAccountTypeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "AccountRequests",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "TransactionalAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "AccountRequests",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Main" },
                    { 2, null, "Secondary" },
                    { 3, null, "Business" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "2b04f828-c0c0-45b8-91a3-61ae9f5443ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "b157e35e-06c1-4898-b46e-9e0e3676fd73");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "b0930aa3-7341-4e62-aa14-815b545f7118");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b93a19d6-8b6c-42a9-8923-001e35e45798", "AQAAAAEAACcQAAAAEFWKMiD0Vaah/90uAT4iwNaUcR7wBYyDObz/Jcy+YQaqPDEZ4FtBW5HRrnUa0JS5gw==", "2826eccb-cb2e-4217-ac32-0ad62ee6ff03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed0209f7-47d9-4dd4-8a14-612238ee3ee5", "AQAAAAEAACcQAAAAEG/zkXSRr/nA+/vMA5SYMcfz/2/Rc3Y0VmYzYUTpeHhF4dsWp4y4o7lNjj4J6TxzMg==", "4e0afd35-a854-498c-88ae-9eed48585e60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ca8bac1-0680-476d-87ea-fcac54408f64", "AQAAAAEAACcQAAAAEMGoCwQMMDQhYfv4v7hfZ5Z0kim17EqU8XiJAfXWgEdSXVk13pZfoYGi4T58ugtIIg==", "9a3c4d25-a6a1-47ae-bb74-9676efb50f50" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "AccountTypeId", "CreationDateTime" },
                values: new object[] { 1, new DateTime(2024, 4, 8, 13, 58, 14, 169, DateTimeKind.Utc).AddTicks(451) });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "AccountTypeId", "CreationDateTime" },
                values: new object[] { 1, new DateTime(2024, 4, 8, 13, 58, 14, 169, DateTimeKind.Utc).AddTicks(447) });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionalAccounts_AccountTypeId",
                table: "TransactionalAccounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRequests_AccountTypeId",
                table: "AccountRequests",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRequests_AccountTypes_AccountTypeId",
                table: "AccountRequests",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionalAccounts_AccountTypes_AccountTypeId",
                table: "TransactionalAccounts",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRequests_AccountTypes_AccountTypeId",
                table: "AccountRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionalAccounts_AccountTypes_AccountTypeId",
                table: "TransactionalAccounts");

            migrationBuilder.DropIndex(
                name: "IX_TransactionalAccounts_AccountTypeId",
                table: "TransactionalAccounts");

            migrationBuilder.DropIndex(
                name: "IX_AccountRequests_AccountTypeId",
                table: "AccountRequests");

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "TransactionalAccounts");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "AccountRequests");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AccountRequests",
                newName: "AccountType");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "d7102851-2446-4f15-811d-472095bf0282");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "274efc0f-e920-4c5a-858e-074e74d952b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "9a124eb5-299a-49dc-9e98-7daa036f2983");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9fbcf6e-30ea-400f-9777-e936b44629b6", "AQAAAAEAACcQAAAAEGyj3igaKsF1Ex+5hMXiwVH2cxEGE5PrMVQugj4aOQlYY72L2Opy6yOm5aDCe3bUow==", "f0665c0d-9bfc-4de4-8e5d-5ccf1be9da08" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a42a829-628c-4d02-89e4-822521df65b7", "AQAAAAEAACcQAAAAEMt9byk7SYhmQ3rMxr9ZKN43uEjLzy9qlQCaMyJnENHpVjDs9rA3QHYHEvfHu6a9ZA==", "24a95dc6-c916-4751-8cc9-764bcc49ad2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "062b77e0-75ca-45eb-9448-3d7ae81b2d52", "AQAAAAEAACcQAAAAEP+qaHxMM5YS0kJ4aAfrFt8T7X+5TGvl961WjqxlJqnwRLr0mkCV5A5xUnlYinOmDA==", "e70de762-38db-4487-aa69-04df80d61d23" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 5, 15, 33, 6, 726, DateTimeKind.Utc).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 5, 15, 33, 6, 726, DateTimeKind.Utc).AddTicks(130));
        }
    }
}
