using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMCS3.Migrations
{
    /// <inheritdoc />
    public partial class addDateApprovedToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "Claims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "Claims");

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
    }
}
