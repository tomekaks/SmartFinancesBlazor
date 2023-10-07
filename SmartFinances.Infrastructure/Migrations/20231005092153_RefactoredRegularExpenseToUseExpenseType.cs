using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class RefactoredRegularExpenseToUseExpenseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "RegularExpenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseTypeId",
                table: "RegularExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "bbe75fd4-e4dc-460c-9c6c-9a6850a9624c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "319c9377-76fb-4f3e-8fa0-12c0adaa4562");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "5fc8850d-ca35-47cb-9d06-4a41e7f4c5b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d2233bf-c060-4ad2-801b-ee2d2b1a5baf", "AQAAAAEAACcQAAAAEDoSFJshobXAF4xgNqrjIrQLCCCltJR5H4+Zn/qLJbyANt6zpsRsWCXj4zvb2VqOhA==", "c4e865ed-0f7d-470b-9738-54fa879e7a1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af1a1e78-a725-4494-971f-86e71b4b0a61", "AQAAAAEAACcQAAAAEARSl68Xqm/T3NWlJWNZg2tg6NA0TGZPEyaHXkB4WBW90wIpzGsIP1tcciTjacT+ag==", "4a225e47-5590-404a-bad5-d2fa2f1f6026" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4809da27-eb11-4ba8-83e3-5de476770f06", "AQAAAAEAACcQAAAAED2jQRvu2EB/omS1ds9ntWOg7PCSGeyJ6vHc19vI3UmlTCw7t75f0jvtGpJR0QFBKA==", "d8cbfd95-2045-4968-af86-cad5ea9b1a39" });

            migrationBuilder.CreateIndex(
                name: "IX_RegularExpenses_ExpenseTypeId",
                table: "RegularExpenses",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegularExpenses_ExpenseTypes_ExpenseTypeId",
                table: "RegularExpenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegularExpenses_ExpenseTypes_ExpenseTypeId",
                table: "RegularExpenses");

            migrationBuilder.DropIndex(
                name: "IX_RegularExpenses_ExpenseTypeId",
                table: "RegularExpenses");

            migrationBuilder.DropColumn(
                name: "ExpenseTypeId",
                table: "RegularExpenses");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RegularExpenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "004accd9-f7cd-43f6-a090-e0d8334fba19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "66c02032-e626-4ee2-bf35-cf4387205c68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "909b097d-8ee1-42e5-a781-ac8a7160cd82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9a54a0e-67b5-421d-b71f-0eed7090704d", "AQAAAAEAACcQAAAAEBrYZ1I/3mYr25oOObFHYMlz+KiV6mnXofa3lU6FqGpwcZP626GQaMbrrh+eMFsf0w==", "47fb63ee-81a8-4e85-8d13-3f561c0a44d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5c63552-0801-4af4-8e9c-a26b01140b2e", "AQAAAAEAACcQAAAAEKD90HSRTEeY4T0YGNvsvG2b5XaDCDqqW4PjrLBNhxawCn8CdGoe8mGOVyJ4CPvGfQ==", "eea9451a-a3a6-4119-8062-6b4b71a3a73a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b937ae9-181b-4a4f-9e62-407c04551bdc", "AQAAAAEAACcQAAAAEC1mm97Etniexzs0oVvQvtpnotpENx3WQLgGcvjKMPA1qfyfA3KRoVbkoen8AgKLZQ==", "dc625e36-0a4b-4fb7-8c57-e0bc7898d314" });
        }
    }
}
