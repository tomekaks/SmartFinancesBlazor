using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class RemovedSenderAndReceiverIdFromTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Transfers");

            migrationBuilder.AlterColumn<string>(
                name: "SenderName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "b86b4b22-bb81-41f7-ba2c-1b88da0ef7af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "2871fa44-d9c9-4a9e-9c62-af3f0c12b94d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "67fae404-7cf8-4265-b599-fd8ef056cc07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d496751d-cb5e-46c9-82ac-91ab8b6a3e4a", "AQAAAAEAACcQAAAAEPeF3LJ/xnvsFPl+k+BxlE+v09F2v2/f4D2uIuTti2OuJwUKwcBF17OBs8/jhSq38w==", "b0ce3004-9521-45f7-b8d6-21f980138430" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ed6533-3f50-4039-bc73-71ad47d910ff", "AQAAAAEAACcQAAAAEG4CQzV/SIKFv9pTScLMCZ+vohXPJmMvkrBhCROP5Sh4+ss+ZLxh/MSOROiqUxh8Tw==", "2b12e512-429e-4042-85a6-dd976c280635" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "177a1f48-da07-4b48-9f4a-d99b63de1561", "AQAAAAEAACcQAAAAENXXDPypNyilR5cIn4pmkSPQF5HmYnCdHnLVa6rLsRte3iHpggtB9V3F9Ck2uquNuQ==", "36a739f6-936a-492c-8d9e-9f3451c9078e" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 26, 14, 8, 12, 334, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 26, 14, 8, 12, 334, DateTimeKind.Utc).AddTicks(4462));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SenderName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
