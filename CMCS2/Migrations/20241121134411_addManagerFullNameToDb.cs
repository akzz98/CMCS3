using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMCS3.Migrations
{
    /// <inheritdoc />
    public partial class addManagerFullNameToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38a9668d-9022-4137-b2f1-b2c1b71ac725");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7be041d7-5247-434b-b7c8-447e9a86a1ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdfe91bd-82c5-4547-82c9-dfd835f10e74");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a37fda58-eb0d-49f2-8277-b1e6be202af7", "e62830f9-69f3-4589-9f82-7e1d938cbaec" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a37fda58-eb0d-49f2-8277-b1e6be202af7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e62830f9-69f3-4589-9f82-7e1d938cbaec");

            migrationBuilder.AddColumn<string>(
                name: "ManagerFullName",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46ce3ec0-15af-499e-aa58-c22da41d15ef", null, "SuperUser", "SUPERUSER" },
                    { "80bf2265-39bd-4cd2-811d-6ca41087775f", null, "Lecturer", "LECTURER" },
                    { "8dce4b94-559d-442e-9df2-519fd416bc7d", null, "Manager", "MANAGER" },
                    { "d91ba30a-aa09-446e-9e25-2a06fbd3622a", null, "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5ec8da5a-543e-4c26-9296-4ed3624090d9", 0, "1dd3fb32-9d70-4a26-9e60-0f6e41294b01", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAEJUmlvUKoHiURFvOB4MWgvwjAQsTKCR/fSIQmcDsju1a02639aES6w5QS/vB3KTCqg==", null, false, "7d5f867d-b651-4e77-ac74-5b5037b7bc6b", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46ce3ec0-15af-499e-aa58-c22da41d15ef", "5ec8da5a-543e-4c26-9296-4ed3624090d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80bf2265-39bd-4cd2-811d-6ca41087775f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dce4b94-559d-442e-9df2-519fd416bc7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91ba30a-aa09-446e-9e25-2a06fbd3622a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46ce3ec0-15af-499e-aa58-c22da41d15ef", "5ec8da5a-543e-4c26-9296-4ed3624090d9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46ce3ec0-15af-499e-aa58-c22da41d15ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ec8da5a-543e-4c26-9296-4ed3624090d9");

            migrationBuilder.DropColumn(
                name: "ManagerFullName",
                table: "Claims");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38a9668d-9022-4137-b2f1-b2c1b71ac725", null, "Coordinator", "COORDINATOR" },
                    { "7be041d7-5247-434b-b7c8-447e9a86a1ec", null, "Lecturer", "LECTURER" },
                    { "a37fda58-eb0d-49f2-8277-b1e6be202af7", null, "SuperUser", "SUPERUSER" },
                    { "bdfe91bd-82c5-4547-82c9-dfd835f10e74", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e62830f9-69f3-4589-9f82-7e1d938cbaec", 0, "4caa24dd-5161-4519-8a4d-b363f04b8192", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAELNFuOcH9oC6Q32o3yG76EhFhC4yKeEkLCZPIppn9oKAQSkJjwnJKZgYbM5LUGDmaA==", null, false, "7db86ae3-5eba-4087-a6df-2fa449f86344", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a37fda58-eb0d-49f2-8277-b1e6be202af7", "e62830f9-69f3-4589-9f82-7e1d938cbaec" });
        }
    }
}
