using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class ChangesInTransferModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
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
                name: "SenderAccountNumber",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Transfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "a6b145ca-da78-4d25-9dc0-1e44755f207e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "c72436ac-efd3-4b55-b02a-f6d83a564bff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "b65fb1c8-4fc8-49e5-9e0f-a247f8ce4dcc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9858349-dda3-4e1b-a739-253ad13ba5d5", "AQAAAAEAACcQAAAAEMQgChw4L2q2M5Ng+Gp4q4rqKxyKtZpexpEgNplWVC1pDwfRwDZmtVpJf5xsHMBl2A==", "49041d5c-6a92-4294-ac1a-d6e348d61e1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63dd4016-e33d-4881-8657-da3475a4e4c3", "AQAAAAEAACcQAAAAEEUEBaEy7vnNeQi3vfkQ77CYgKBWXuKvgQBIKPv9Noyg4ISfqn0yfN6xC5LLD8kjIg==", "64b9786b-088d-4567-a401-6b0d77c564d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8214ad36-9057-48e0-a7ba-441cae22dd79", "AQAAAAEAACcQAAAAEI5JeQWFrk+ihMLEpPfLMM6fva3a2d0gJY8+k3q1JRT/QawiP17/PUhnkeijsH1zmA==", "af915c2a-9d59-4d80-8531-67cfd7445281" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
                table: "Transfers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
                table: "Transfers");

            migrationBuilder.AlterColumn<string>(
                name: "SenderName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SenderAccountNumber",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "eaa3e751-bb19-4583-b61a-e2c7dfc0abc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "917bb97c-2b00-4efe-a761-a544dbc4b7ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "b324d314-29ee-4405-9f72-17ac3aa74051");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebb4a702-49a1-44bd-8cff-898ed8440af6", "AQAAAAEAACcQAAAAEMjLMjg2m0fRsr3X0vugNCJ+J3v5F8Zp1ZsDfDEDaWxljtOz7/NIp6fUyNKduDwwjg==", "c961be3e-1d49-4c64-85b3-f7c18a45e9f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcb5c1b9-ae9f-44bb-a7a4-ff73b2b9ee9c", "AQAAAAEAACcQAAAAEMlmbIED9jKLM1cgp0jnT5X++BIJR8knlQdLYtG8gr0GgOKUXZ0yzbgZHkroSTIymA==", "4c8860f4-5ea2-4296-a449-cfa75033b2cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4159ac76-6a9e-46c1-b7a2-fe7200f807a9", "AQAAAAEAACcQAAAAEPeJBLD6lkxh5TKF2ksvFSq+iVuIZjdAnUDGaFj/gqU75NJyXXA1J1ttAtDdkYPqYw==", "21ca95d5-4c69-4216-aad8-19d269a84bdd" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_AccountId",
                table: "Transfers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
