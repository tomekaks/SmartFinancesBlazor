using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartFinances.Infrastructure.Migrations
{
    public partial class AddAccountRequestAndNotificationClassesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateApproved = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "13fa5548-c6b6-4865-a8e3-59ac42d149ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "8359933b-ae4f-4490-91ef-883e5618f83b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "262b082a-1f1c-4181-bde8-9920bea844b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "493c909a-7e9e-435c-a91e-ad23409bbd0c", "AQAAAAEAACcQAAAAEFuM9xfhtRS4uZ9zaJe1OB8MpS4y57q20B85i+offuUmtud0fhofFQSZKePxJE6KGA==", "17f6f42d-94f2-43c7-8d75-5b3e6b84a471" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55972af5-84fb-4e59-a45e-9a72416b9856", "AQAAAAEAACcQAAAAEL+b+4wu/OVwftgqwfj76XABzNVuxe61/XRpIduY2nafFdMYhU0pE5UEqVrYFzUwgQ==", "08687dc3-72a6-4798-885c-21b5236dfd89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0599184f-ad51-47c8-92b3-1a74c6ca2a59", "AQAAAAEAACcQAAAAEDwcqj5iOlPgSw2xyhhCWuv0mHRUAp+e8PChuGiwvgoj4j/YTBSzhvykqBBmCHJt8Q==", "b01e23ce-ed2a-494b-a2b5-1151a49436ad" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 1, 14, 1, 48, 741, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 4, 1, 14, 1, 48, 741, DateTimeKind.Utc).AddTicks(6941));

            migrationBuilder.CreateIndex(
                name: "IX_AccountRequests_UserId",
                table: "AccountRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRequests");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abebd04b-4c91-40ca-a99e-8577ff0f262e",
                column: "ConcurrencyStamp",
                value: "b86b4b22-bb81-41f7-ba2c-1b88da0ef7af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dea03c83-9eae-4ce3-9560-7b3aec0f1b00",
                column: "ConcurrencyStamp",
                value: "2871fa44-d9c9-4a9e-9c62-af3f0c12b94d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee6ef51f-eaf9-406e-863e-b8012bd7045a",
                column: "ConcurrencyStamp",
                value: "67fae404-7cf8-4265-b599-fd8ef056cc07");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5330c916-053d-41e6-8a44-b9fe25cf27bf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d496751d-cb5e-46c9-82ac-91ab8b6a3e4a", "AQAAAAEAACcQAAAAEPeF3LJ/xnvsFPl+k+BxlE+v09F2v2/f4D2uIuTti2OuJwUKwcBF17OBs8/jhSq38w==", "b0ce3004-9521-45f7-b8d6-21f980138430" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f095269-a72b-4427-bcaf-d860249770c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ed6533-3f50-4039-bc73-71ad47d910ff", "AQAAAAEAACcQAAAAEG4CQzV/SIKFv9pTScLMCZ+vohXPJmMvkrBhCROP5Sh4+ss+ZLxh/MSOROiqUxh8Tw==", "2b12e512-429e-4042-85a6-dd976c280635" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef201b2-999c-4161-8f2b-d7994971e5ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "177a1f48-da07-4b48-9f4a-d99b63de1561", "AQAAAAEAACcQAAAAENXXDPypNyilR5cIn4pmkSPQF5HmYnCdHnLVa6rLsRte3iHpggtB9V3F9Ck2uquNuQ==", "36a739f6-936a-492c-8d9e-9f3451c9078e" });

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 26, 14, 8, 12, 334, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "TransactionalAccounts",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDateTime",
                value: new DateTime(2024, 3, 26, 14, 8, 12, 334, DateTimeKind.Utc).AddTicks(4462));
        }
    }
}
