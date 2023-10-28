using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class SeedDataAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "fd8a923a-cab1-424d-94a9-a5fdb6e36f84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "791c9e43-a64f-437d-b2c2-de2431772d76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "b4f079c7-12fc-4a79-b234-91ccf62e76a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8b3d5fa-286e-4233-a2f7-ffdf645c7b57", "AQAAAAEAACcQAAAAEIwH5zBG1K6h3PZ1oiXphAUb0KfoLhVJYEkH3zj15QDP9y1HapRERhiBKSNs3F1ANw==", "cecbb5f9-43de-4c39-8ba4-83273fb9bb21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a2b3577-2a0c-4bec-97d5-35df2b93fe1e", "AQAAAAEAACcQAAAAEHzoaPVYpO/CCt/viidunroe32/CxIQ/obIKN/HvTDyIwvjcC01BH+j4U+CkekjuMw==", "48991d5f-06b8-45f0-997d-352cb507dc12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04ca9541-e3f0-4d48-b2c7-9ac87cdfadb3", "AQAAAAEAACcQAAAAEJnW5v89WHwEZwXkp+SlJcCfwfTS7R2N4vhYMHMwwPzE1v9gy/TL4mI6/4YK7TVNaA==", "98145324-ef67-485b-a1cb-097b6dcd3ec2" });
        }
    }
}
