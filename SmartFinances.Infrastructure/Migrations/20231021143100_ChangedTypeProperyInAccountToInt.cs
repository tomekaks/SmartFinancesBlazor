using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class ChangedTypeProperyInAccountToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "Type",
                value: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "Type",
                value: "Main");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "Type",
                value: "Main");

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
        }
    }
}
