using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class SeedAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "eea15ae5-3502-4d21-b9af-46475b4b8233");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "f53fed61-e324-4bef-a86a-6b85b9151a35");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "cd4561fb-17f3-4091-990b-c047cfcf38e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd734e22-259f-4b11-9c61-7fc10bc5ad1d", "AQAAAAEAACcQAAAAEMvvCSVqDHqcq1t0isdaF6joCxPSK5D/vSyWgFkL+RAX2E3dtmPp2kadlpcCSrOLcQ==", "f58c7e2f-d39b-4e14-9849-5438f441288f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dad796f-d218-4c62-a9ab-2ccbb7180d61", "AQAAAAEAACcQAAAAEGhNP+9fKBx2Zm35efEzfd+XoXR67TKJx7LHwEpONne4bq6YJbt/8C0zwvLEt8DcXQ==", "11307930-7921-4813-ba92-281e1ccb45a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3889e97f-5f55-4394-8f39-a1e6c8a266bc", "AQAAAAEAACcQAAAAEJIvVPeM/ryzhCqWQBfs/3J7xvSl+IuJgujxwW5JaQ4nU2BIjBIpyCYS43DFpFBI0g==", "a01c0e7e-6659-47fe-b197-1cbef6382d40" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 25, 10, 45, 8, 993, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 25, 10, 45, 8, 993, DateTimeKind.Utc).AddTicks(5057));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "a6540a8d-1e1f-4770-a23b-8253acb43b7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "e94f67e2-f3d4-4b4a-8899-6081cbf4aa9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "32570c0e-556a-40f1-be93-25006ed9a977");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1207bc9e-4fb9-4cbb-bdb7-7f2077097dca", "AQAAAAEAACcQAAAAECgnzMw5Lkd2CQQ/d3hK/pOoyV6liZIb0AIPmjirGK631vBr2bTMDh8XCw3o28fQnQ==", "367bb42b-66b8-413c-98af-80c0e0f9d94b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a57d021c-a97a-4814-ac2f-def74b45bc4a", "AQAAAAEAACcQAAAAEFA2Xj+Y7vDGIjExR/y5f1pOISqkpHmgDm3FSKt5vLz/b2Tjq2tBFWDbzXLrAt4RQA==", "a5703533-feff-4b0b-9d0d-39a00a329d56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2a5924f-7101-4e86-b8c7-f2d897e8f574", "AQAAAAEAACcQAAAAEN2QXPvGApPFUIiNV3PjkTHB0scBWjP9onyJ7/sQtomltUnd3ZuScc0rC56RcysQUw==", "cece831b-b156-44c9-bc35-8f74a4578567" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 24, 15, 58, 2, 32, DateTimeKind.Utc).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 24, 15, 58, 2, 32, DateTimeKind.Utc).AddTicks(3552));
        }
    }
}
