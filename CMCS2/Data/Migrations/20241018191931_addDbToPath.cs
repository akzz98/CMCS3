using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMCS2.Migrations
{
    /// <inheritdoc />
    public partial class addDbToPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb6be6a8-d80c-43e8-8e16-bcf056ccd112");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1f81752-9514-486a-9d38-3c85a10450ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e17f8afc-f7c2-45d1-a0b0-efd459d38071");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be94b311-840a-4f3f-b98b-a23ae068ec65", "4ad4628d-c9cc-4434-b949-25de2fba5179" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be94b311-840a-4f3f-b98b-a23ae068ec65");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ad4628d-c9cc-4434-b949-25de2fba5179");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00165150-91c0-4c1d-997a-f1f958b00ef4", null, "Manager", "MANAGER" },
                    { "04afeb14-5db3-40a2-88ce-b714d836e1fa", null, "Lecturer", "LECTURER" },
                    { "1a703ccf-9d40-4969-891d-a39595ae5431", null, "SuperUser", "SUPERUSER" },
                    { "2681de76-c7b3-4674-b1b0-23db0c971838", null, "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3e0d0c68-38ae-4f9c-9b66-605fa161f88e", 0, "d7849607-ef40-41cd-bb28-9c0c9d8c0b4c", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAEAIQR+eWZTgi+A73CXIreP1AZlbfOvF61gvdypM8TdEiKFZfwacwk2EEsdP9h1Y1YA==", null, false, "8b1a671b-5b95-455a-85b4-862a70fdb218", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1a703ccf-9d40-4969-891d-a39595ae5431", "3e0d0c68-38ae-4f9c-9b66-605fa161f88e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00165150-91c0-4c1d-997a-f1f958b00ef4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04afeb14-5db3-40a2-88ce-b714d836e1fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2681de76-c7b3-4674-b1b0-23db0c971838");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a703ccf-9d40-4969-891d-a39595ae5431", "3e0d0c68-38ae-4f9c-9b66-605fa161f88e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a703ccf-9d40-4969-891d-a39595ae5431");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e0d0c68-38ae-4f9c-9b66-605fa161f88e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bb6be6a8-d80c-43e8-8e16-bcf056ccd112", null, "Coordinator", "COORDINATOR" },
                    { "be94b311-840a-4f3f-b98b-a23ae068ec65", null, "SuperUser", "SUPERUSER" },
                    { "c1f81752-9514-486a-9d38-3c85a10450ad", null, "Lecturer", "LECTURER" },
                    { "e17f8afc-f7c2-45d1-a0b0-efd459d38071", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ad4628d-c9cc-4434-b949-25de2fba5179", 0, "5edd2573-fc7d-458b-8f72-5a8cba3913a2", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAENg3y/TC42Jtbjobyo/sboNohIY/EU4u7unX+FirGxVfGwZ7gp3iebAfMDmEYDukAg==", null, false, "10b0d86f-c90e-48a1-b112-9b7117ab70f0", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be94b311-840a-4f3f-b98b-a23ae068ec65", "4ad4628d-c9cc-4434-b949-25de2fba5179" });
        }
    }
}
