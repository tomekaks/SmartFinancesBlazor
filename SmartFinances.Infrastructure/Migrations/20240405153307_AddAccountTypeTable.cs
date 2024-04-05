using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddAccountTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_Name",
                table: "AccountTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "0828a256-3d96-41e4-8417-901f0ebcf8e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "5167f5ef-105f-4bcb-96e3-da0b43cf4464");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "12fa6183-a99c-42f7-acb6-7160219e493a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62808a45-30ef-49c8-b397-8f84683779c8", "AQAAAAEAACcQAAAAEC+n6UNJk7eYdYuuLu3QgUDbBTx14qe8JajOJe1ixTyhCrerkWDil8qPGj/gMTe70w==", "4592c7ac-1603-42a6-98fa-fe53317e22d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b722a33-bf8c-4cf0-9349-196b0f0cbb80", "AQAAAAEAACcQAAAAEBnOXUo5k7UNa0csiEjmVJ0Gh643iSQIHJ4OA8eqGC+AKaf0Irvke5ZDwAoGeYKbXg==", "50179af3-002a-4b90-bd4e-ce895d0462d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71b75440-808e-4e41-b88d-d51b8bbc8633", "AQAAAAEAACcQAAAAEKj67liyoN0pFBYHLcGxqAmEnHa8zPUgcKOC3IMtLUWaSwt3sYZ30wZmmlD1G3udpA==", "1c699bb3-134d-4272-804f-b6824cd26eb9" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 2, 12, 12, 43, 840, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 2, 12, 12, 43, 840, DateTimeKind.Utc).AddTicks(9001));
        }
    }
}
