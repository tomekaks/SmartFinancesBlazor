using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddRelationshipBetweenAccountTypeAndAccountRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountTypeId",
                table: "AccountRequests",
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
                value: "18384d78-f3ba-4883-b7cf-1e4ff1704b14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "79e8a294-6852-4109-999d-8a845f0f8482");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "cd153979-9a80-4827-8d73-194d1b6b773a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db7b65b3-6d9a-41f6-9903-6d2e463d428d", "AQAAAAEAACcQAAAAEPhVxBRAWs1SJwc/lXxEZJhxLJo4C+sQ83cYs1TytdPQ3lDgzXrWUkvDtIQXaGPCfQ==", "60c9b22c-6a63-49e6-a273-9ef5e3757831" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b163635a-be0f-4497-9df1-067ae7f052f8", "AQAAAAEAACcQAAAAEJoLXWlGcZm703AVX67R2ArOwMU5eZIajLy0RQVELAwHSfLJ/aoRRG4GE4VT92WBNA==", "41670bfe-2562-4b5d-9959-41510cf3c864" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88aa881f-a81f-48ad-b158-fc51775a455b", "AQAAAAEAACcQAAAAEKVEJ5in2ZKFhIXFwfx3lCLw0DgajqCxceXjGritzyURbX75+n23Zcszrr6AesRxDg==", "c963bc96-534e-4389-9c11-0877d402eff9" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 8, 14, 1, 13, 155, DateTimeKind.Utc).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 8, 14, 1, 13, 155, DateTimeKind.Utc).AddTicks(6619));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountTypeId",
                table: "AccountRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 8, 13, 58, 14, 169, DateTimeKind.Utc).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 8, 13, 58, 14, 169, DateTimeKind.Utc).AddTicks(447));
        }
    }
}
