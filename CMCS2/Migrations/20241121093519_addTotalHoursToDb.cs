using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMCS3.Migrations
{
    /// <inheritdoc />
    public partial class addTotalHoursToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07d9d6e7-ecd7-4b50-91c8-0bfe0dac3d79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27b52031-2e93-4f18-a2d5-a5bd1575131b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5352efe-f602-46fa-8aa2-57116688d71a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eaa1ad71-203e-487c-b9a6-3100379a643d", "635da86c-d2de-4e31-8e61-7317841f5c7f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaa1ad71-203e-487c-b9a6-3100379a643d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "635da86c-d2de-4e31-8e61-7317841f5c7f");

            migrationBuilder.AddColumn<double>(
                name: "TotalPayment",
                table: "Claims",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TotalPayment",
                table: "Claims");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07d9d6e7-ecd7-4b50-91c8-0bfe0dac3d79", null, "Coordinator", "COORDINATOR" },
                    { "27b52031-2e93-4f18-a2d5-a5bd1575131b", null, "Lecturer", "LECTURER" },
                    { "a5352efe-f602-46fa-8aa2-57116688d71a", null, "Manager", "MANAGER" },
                    { "eaa1ad71-203e-487c-b9a6-3100379a643d", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "635da86c-d2de-4e31-8e61-7317841f5c7f", 0, "cee69810-01bd-4d0b-abad-c99c65f92ec4", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAENOGdPWF9CSzotymdP+chzvqDdmrita0yj03pBmOWcBn74ipSLJh1oMi/CLfDLO7qw==", null, false, "de8e8470-1e87-45ab-9ef1-9839a63df9d6", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eaa1ad71-203e-487c-b9a6-3100379a643d", "635da86c-d2de-4e31-8e61-7317841f5c7f" });
        }
    }
}
