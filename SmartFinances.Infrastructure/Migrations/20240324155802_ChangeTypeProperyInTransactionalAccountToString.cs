using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class ChangeTypeProperyInTransactionalAccountToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TransactionalAccounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                columns: new[] { "CreationDateTime", "Type" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 58, 2, 32, DateTimeKind.Utc).AddTicks(3554), "Main" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDateTime", "Type" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 58, 2, 32, DateTimeKind.Utc).AddTicks(3552), "Main" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "TransactionalAccounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                columns: new[] { "CreationDateTime", "Type" },
                values: new object[] { new DateTime(2024, 3, 23, 16, 3, 17, 797, DateTimeKind.Utc).AddTicks(4083), 1 });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreationDateTime", "Type" },
                values: new object[] { new DateTime(2024, 3, 23, 16, 3, 17, 797, DateTimeKind.Utc).AddTicks(4081), 1 });
        }
    }
}
