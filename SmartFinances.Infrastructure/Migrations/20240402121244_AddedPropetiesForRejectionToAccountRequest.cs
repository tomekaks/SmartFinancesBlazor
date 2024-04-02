using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddedPropetiesForRejectionToAccountRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRejected",
                table: "AccountRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectedBy",
                table: "AccountRequests",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRejected",
                table: "AccountRequests");

            migrationBuilder.DropColumn(
                name: "RejectedBy",
                table: "AccountRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "13fa5548-c6b6-4865-a8e3-59ac42d149ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "8359933b-ae4f-4490-91ef-883e5618f83b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "262b082a-1f1c-4181-bde8-9920bea844b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "493c909a-7e9e-435c-a91e-ad23409bbd0c", "AQAAAAEAACcQAAAAEFuM9xfhtRS4uZ9zaJe1OB8MpS4y57q20B85i+offuUmtud0fhofFQSZKePxJE6KGA==", "17f6f42d-94f2-43c7-8d75-5b3e6b84a471" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55972af5-84fb-4e59-a45e-9a72416b9856", "AQAAAAEAACcQAAAAEL+b+4wu/OVwftgqwfj76XABzNVuxe61/XRpIduY2nafFdMYhU0pE5UEqVrYFzUwgQ==", "08687dc3-72a6-4798-885c-21b5236dfd89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0599184f-ad51-47c8-92b3-1a74c6ca2a59", "AQAAAAEAACcQAAAAEDwcqj5iOlPgSw2xyhhCWuv0mHRUAp+e8PChuGiwvgoj4j/YTBSzhvykqBBmCHJt8Q==", "b01e23ce-ed2a-494b-a2b5-1151a49436ad" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 1, 14, 1, 48, 741, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 1, 14, 1, 48, 741, DateTimeKind.Utc).AddTicks(6941));
        }
    }
}
