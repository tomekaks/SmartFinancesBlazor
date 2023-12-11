using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddYearlyAndMonthlySummariesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Accounts_AccountId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Expenses",
                newName: "MonthlySummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_AccountId",
                table: "Expenses",
                newName: "IX_Expenses_MonthlySummaryId");

            migrationBuilder.CreateTable(
                name: "YearlySummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountSaved = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlySummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearlySummaries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthlySummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountSaved = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearlySummaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlySummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlySummaries_YearlySummaries_YearlySummaryId",
                        column: x => x.YearlySummaryId,
                        principalTable: "YearlySummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "6e2ddc07-da93-4d5e-b34b-8a076a568cdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "38be67b5-6a6d-4209-a11e-757dd02a9177");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "fde9113c-52b7-496a-ad0c-4b1077a77d29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ebd2c48-af2b-482e-88cc-ba071a0c0691", "AQAAAAEAACcQAAAAENx+5GwFuux9EhtmWy+PPYqmcaU5m0qqBxd/A2ZNQ5nfeW5KxdLo1k4BQz16n9fO5A==", "861d6332-c348-4367-ab14-cc585be60a30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc7b4e7c-164e-40ad-9db4-55e390a0ecbe", "AQAAAAEAACcQAAAAEIrcwZkDQFK9tT3G/VUHVB8cL1fCHOfYhJoo3Y9HWsKel29QzUAw45DqX1wCf/JLHw==", "83b58101-62a8-4772-8df7-237b04ce759a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59f8773c-7c42-42a1-8563-14d34d8bb305", "AQAAAAEAACcQAAAAEJIzWSV+7JkstFV/Wpzr8nSap2041VNH5KOJw/ZjSgeydZI7NdXVi64XhLzAL+7teg==", "9f429d6f-fcae-472f-8e9b-329477c9e7fb" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySummaries_YearlySummaryId",
                table: "MonthlySummaries",
                column: "YearlySummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_YearlySummaries_AccountId",
                table: "YearlySummaries",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_MonthlySummaries_MonthlySummaryId",
                table: "Expenses",
                column: "MonthlySummaryId",
                principalTable: "MonthlySummaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_MonthlySummaries_MonthlySummaryId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "MonthlySummaries");

            migrationBuilder.DropTable(
                name: "YearlySummaries");

            migrationBuilder.RenameColumn(
                name: "MonthlySummaryId",
                table: "Expenses",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_MonthlySummaryId",
                table: "Expenses",
                newName: "IX_Expenses_AccountId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "5e28ea23-b28f-4910-abe3-7c65463d93c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "6d7f4618-4b62-4e1c-b091-7c58f267d22e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "4e65cc54-6a89-4531-9692-3f951223fa57");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6b9fcb9-1a6d-4a19-8114-0d29a9c3e1d9", "AQAAAAEAACcQAAAAEFRIAkFYI6LQPMClkXwLejIFuMIfa3KEINjPxa5olTjrjxKO4z4r/UbMt8/+ijX8JQ==", "aaec16bd-6053-4b97-901f-77d0c5c25094" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6109c1e-3514-496e-bd82-3695953627bb", "AQAAAAEAACcQAAAAEIC9EMxB3NWprqPHT4kUE/b43+Lu24uuBngGNVo+4PE97hz8kW1hCtSVACfwAwFTqQ==", "9527b3e6-f36b-4a16-903c-c0eadef42ed1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "182a75fa-1cc0-4a8d-b024-940fe81ff72f", "AQAAAAEAACcQAAAAEKXw8VyV6GEhPy8AyTc5aP+FdFTFGXZe9mNKG3QVpf0KP/gk4Wcn5lFQ/zcdUbv7Hg==", "f2abdcfd-d8de-4c33-a9b4-454d06d65bca" });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Accounts_AccountId",
                table: "Expenses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
