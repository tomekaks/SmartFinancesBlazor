using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class SeedAccountTypeDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Manage your everyday expenses with ease. A Secondary Account offers all the transactional features of your Main Account, allowing you to separate personal spending, track budgets, and maintain better financial organization.");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Designed for entrepreneurs and small businesses, the Business Account provides specialized tools for managing company finances. Enjoy streamlined transactions, expense tracking, and dedicated support to help your business thrive.");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Grow your wealth securely with our Savings Account. Benefit from competitive interest rates, automatic savings plans, and robust security features to ensure your funds are always protected and working for you.");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "70908557-212a-46fc-97ec-625c831077de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "8e1e3d91-8bee-4a84-a711-7f2a60df8a20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "bad56d15-77c6-480e-93ab-c1467ba47627");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ede4aa2c-2518-44f0-b686-687bff375b69", "AQAAAAEAACcQAAAAEHsi3Mo/3aF1SoPx1QLeeh9IkhhJGS4JhloQyGPTp45lCNFL2t1q+PKFf+Lg2P406A==", "bd4af821-4e13-4322-a49c-55b4ff3dbac2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbf82213-7dcc-49e7-a965-9dc76c1be32b", "AQAAAAEAACcQAAAAEP7C1Varuk63fpYlFTT3FDSNZgMdxgRjCnH0qy21QgbmktQpqEUSNtdfkRLpF/x93Q==", "896d3725-b16f-43b7-a2aa-721be98ab803" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "293e5377-becd-4f1b-9056-ad445c52dff9", "AQAAAAEAACcQAAAAEPQ/Ea+KDMETcV6Xo5icFe6Ic5pPGbXD6lIOgAIfoiu+7ImyhFojziAZxa9K+78XDQ==", "21bf7e85-adc3-467e-b365-12681409271a" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 11, 5, 15, 5, 20, 91, DateTimeKind.Utc).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 11, 5, 15, 5, 20, 91, DateTimeKind.Utc).AddTicks(5376));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "e9ea9cff-70e8-4cd4-bd2d-a2ee4152e841");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "259e85b4-3484-4aa7-9067-18e34cd949b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "39ffecf1-83b2-4b05-938c-ba05fcc995ea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d20c1f61-b409-4c2d-ba98-a341b4c5d7b6", "AQAAAAEAACcQAAAAEEd6cCSkQFKyemA1NG6gd0e+ju9Ibubw87nv64x0pS3YNpgXWKtcT/tecormEh+U1w==", "613822bf-b17d-49a4-87f3-cdd16a2c5369" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcbf241a-dcc7-45dd-8505-5fc868b7ab83", "AQAAAAEAACcQAAAAECCKY9a1C3gW11lADEqVJdEiD8wkGljOQ5nrnDdj7gbfjI8JViEI+vjuLMBbeEfxuA==", "b35cd404-2f34-41b2-93e7-cc9c8a1e67c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a40969b-9aa6-42cf-acd1-adbc83bea600", "AQAAAAEAACcQAAAAECI6KfdAZAXyNa1gOwfiAaQ5BA6TsqFyLwytBH3VCHgkcCi/OwuO+asEV8AGXNW5UQ==", "2c7ba86b-fe9b-4b42-a88a-56a75ce1e865" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 9, 13, 39, 3, 972, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 9, 13, 39, 3, 972, DateTimeKind.Utc).AddTicks(3482));
        }
    }
}
