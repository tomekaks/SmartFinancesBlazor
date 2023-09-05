using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class ChangesInModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegular",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SenderAccountNumber",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "RegularExpenses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RegularExpenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAccounts",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "cc646c3d-cac1-414b-90a2-830b11a627fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "5ac59f5c-2532-4797-9603-64ca502a7bad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "5bf9bfe4-f5e8-4562-af78-11c8d9fe4140");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bf2ff6e-80c5-4cba-94b3-6cdd8e6aca27", "AQAAAAEAACcQAAAAEJ8mh5vRqeOMtzhNDp9yF5Ls9F7Yjb7l6hmShDgzLzbMYEUIvOihb03rsD0S/T7hag==", "ea8a4001-0493-45b6-80ff-a3e1a6ebf352" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59865b8f-aeae-449b-a3b9-80ab780a54cd", "AQAAAAEAACcQAAAAEIqzRZx5/s6DVvLFH1GqhpbpwCQEc91zBipq6TC2FKTCMdQmiqTLJnNm19YH27bH1g==", "84f37f77-7d92-46cd-8b87-1626964838a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4a91669-ff17-4e03-9ceb-af1067495aca", "AQAAAAEAACcQAAAAELIKYNqzKHa4BqQ8sKObrWhe+3Vhl252iXQF+idfUKz8VhJ1vLt3zRUM5vHCz8++xw==", "f132b133-7d94-4568-a502-e9eb103c5663" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "SenderAccountNumber",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "NumberOfAccounts",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "RegularExpenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RegularExpenses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsRegular",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "f9e93179-5bf2-4efc-ab8a-5694924a4225");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "8aace336-4edd-4cb6-9eb9-80d3e114ef21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "d3e34584-d137-4e4e-b577-7dc413b8a759");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1e91907-4198-4ffa-9770-f1053f2d389c", "AQAAAAEAACcQAAAAED4zcGhwQAWCxoDpPdspB2l8gRRVSG6KRepll3+iyHmlc/fG4dYyqf73fP43mllpQQ==", "4a2d0d9a-d925-49a2-a2e7-6c96e126781f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ec2edf2-acac-4c6d-b232-a5b81a5dc987", "AQAAAAEAACcQAAAAEL1gwcASyHWciU1Pfuj2dIHO/Ip+eUG9UYGcTAZmsy08gasgkBckBqTIL4oy2TDuFw==", "beaab229-0397-44c6-96aa-fd0d8c33db16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "532ad534-7779-4d1f-8dc9-e1a01a6dbc71", "AQAAAAEAACcQAAAAEOnZC6RIxLi313SKcNoxtryDulakH59ZRxWkmHVVwdiMYWdJejVDI8ppPUeohjKU5g==", "ce2ebf19-2e4a-4112-9a82-a93377feccce" });
        }
    }
}
