using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class SeedMoreAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "Budget", "Number", "Type", "UserId" },
                values: new object[,]
                {
                    { -4, 2000m, 0m, "44DDDD444444", 3, "8f095269-a72b-4427-bcaf-d860249770c9" },
                    { -3, 2000m, 0m, "33CCCC333333", 2, "9ef201b2-999c-4161-8f2b-d7994971e5ee" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "64487dc0-f202-44ed-ac93-1217d7d1a1b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "de929e7e-8463-456f-bb32-18be75a368bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "43eaeca9-bf6d-41a2-aff4-d00232f42751");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8693463e-043a-48f4-ae88-6b6f97dd717f", "AQAAAAEAACcQAAAAEA1Do+WSW83eoJ4uRouf86dSbGMNcBYvdxtGhxGy9gxkfmf89L+ng6FKjvkpDaVPhg==", "c40035e8-3757-4350-a15f-8cee30a4ff56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "688d64a0-b347-4d42-bc64-3bd4ad6c48f9", "AQAAAAEAACcQAAAAEJRuCA72xmaDNGx+zHM+gPRKzj3zKqzZvLJzkCkwnJp7QHh3d4nvWne9JLzd/1gPrQ==", "02d06423-2b32-40b2-b29b-8cb2bdae6d16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49b3945c-0b1f-48fc-a2bc-af6809108348", "AQAAAAEAACcQAAAAEMT5UQTCKm+NIDmaBsXKsixcgMzjIEVqep93EP8IIgjs+EOFRQcg3fx2WPb88432lw==", "dfde8a92-52f4-4692-8c5e-c8b73be648d3" });
        }
    }
}
