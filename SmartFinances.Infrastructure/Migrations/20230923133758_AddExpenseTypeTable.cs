using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddExpenseTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseTypeId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Housing" },
                    { 2, null, "Utilities" },
                    { 3, null, "Food" },
                    { 4, null, "Clothes" },
                    { 5, null, "Health" },
                    { 6, null, "Entertainment" },
                    { 7, null, "Transportation" },
                    { 8, null, "Personal" },
                    { 9, null, "Household" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_Name",
                table: "ExpenseTypes",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
