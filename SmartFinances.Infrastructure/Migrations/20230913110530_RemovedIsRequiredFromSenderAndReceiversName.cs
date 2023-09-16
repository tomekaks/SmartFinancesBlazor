using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class RemovedIsRequiredFromSenderAndReceiversName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "25e8f60d-842a-4f6d-8337-e7ac443399e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "f7f956cf-ec3c-446b-8cc9-5c7944b063f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "241b38eb-6de3-449c-be31-51abf75dd69a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31ae1810-7742-4067-b392-fd3e6f634056", "AQAAAAEAACcQAAAAECKWD9hFbQyyOgJNqfsCTiDm4uArmHVaSJHfLFu6+i7qp67LBUCesXrTEXAbOjpnBw==", "cac1551a-fc51-4d5d-9050-a96a099bb852" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9086c218-6a38-44c0-abd8-2b4953b7967c", "AQAAAAEAACcQAAAAEBGhMCi0SoS/x8A2fHifpEubN+Ak/HmLIY4koSHA2cbpYztK0QfOJ3FuGaiWw2378w==", "9f02f617-46b6-430f-9ee7-b7bad90b407d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0ad147f-fe35-44f5-91b7-5cd5458fb216", "AQAAAAEAACcQAAAAEFN1QN6+Z8paGXXQtlYDmS89YI/4xIWgBffxZScNexovfSZyKZLN8O9VLEexztgYbw==", "866bc2a5-b550-4109-84a8-ca7215f8c7a2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
