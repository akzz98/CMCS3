using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMCS3.Migrations
{
    /// <inheritdoc />
    public partial class initMigrateAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2809dd2b-ad94-4273-993f-8e265543f06d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "877318a5-6d82-4825-b7cf-9d9629cabb52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9719c40-5240-44a9-b77f-7343eef9ea8b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "083a4420-ffb9-424e-8a71-cdc5339390f3", "bfdbef1f-f9b8-4a9b-9620-6e754a5e8d17" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "083a4420-ffb9-424e-8a71-cdc5339390f3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfdbef1f-f9b8-4a9b-9620-6e754a5e8d17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d4b7948-da11-47bc-a998-68abaf720f94", null, "SuperUser", "SUPERUSER" },
                    { "297bbdb9-4936-4c31-b07a-bc3c4b92d300", null, "Coordinator", "COORDINATOR" },
                    { "4e3b47e5-da56-4076-b1aa-7c25910a4fd0", null, "Lecturer", "LECTURER" },
                    { "ce114661-fa8f-4311-807e-d7222f7aa934", null, "Manager", "MANAGER" },
                    { "f6a81e48-af04-413c-9153-64ff4f912858", null, "HR", "HR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9dd8f474-9ec7-4b6c-ac2e-49e83ab5f3f1", 0, "e8d74c5f-600b-4a5b-bae3-2154ade1faba", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAEHqp+pSmqOw2iFX2cCxmRBMklxYZpMvJA6OQLHi+wMWmqiTCcT3lUtciiSwvICmAEw==", null, false, "85d75f52-8d97-47ec-a6f3-345c12f80937", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1d4b7948-da11-47bc-a998-68abaf720f94", "9dd8f474-9ec7-4b6c-ac2e-49e83ab5f3f1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297bbdb9-4936-4c31-b07a-bc3c4b92d300");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e3b47e5-da56-4076-b1aa-7c25910a4fd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce114661-fa8f-4311-807e-d7222f7aa934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6a81e48-af04-413c-9153-64ff4f912858");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1d4b7948-da11-47bc-a998-68abaf720f94", "9dd8f474-9ec7-4b6c-ac2e-49e83ab5f3f1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d4b7948-da11-47bc-a998-68abaf720f94");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9dd8f474-9ec7-4b6c-ac2e-49e83ab5f3f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "083a4420-ffb9-424e-8a71-cdc5339390f3", null, "SuperUser", "SUPERUSER" },
                    { "2809dd2b-ad94-4273-993f-8e265543f06d", null, "Manager", "MANAGER" },
                    { "877318a5-6d82-4825-b7cf-9d9629cabb52", null, "Lecturer", "LECTURER" },
                    { "d9719c40-5240-44a9-b77f-7343eef9ea8b", null, "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bfdbef1f-f9b8-4a9b-9620-6e754a5e8d17", 0, "32950650-25a5-4cc4-983e-8c4a1b1d1e02", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAEI38D+rNZqAVFaAx0NeRd37T7sW316BzDH/piY9d+7iF6XeuBWfMEQ0r9n/h8vfAgw==", null, false, "04ff7a48-d239-471a-b2b9-a3b2d3c1c533", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "083a4420-ffb9-424e-8a71-cdc5339390f3", "bfdbef1f-f9b8-4a9b-9620-6e754a5e8d17" });
        }
    }
}
