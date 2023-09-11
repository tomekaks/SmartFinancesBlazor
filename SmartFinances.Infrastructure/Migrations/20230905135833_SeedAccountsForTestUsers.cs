using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class SeedAccountsForTestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "Budget", "Number", "Type", "UserId" },
                values: new object[,]
                {
                    { -2, 2000m, 0m, "22BBBB222222", "Main", "8f095269-a72b-4427-bcaf-d860249770c9" },
                    { -1, 2000m, 0m, "11AAAA111111", "Main", "9ef201b2-999c-4161-8f2b-d7994971e5ee" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
