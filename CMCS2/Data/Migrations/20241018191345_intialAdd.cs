using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CMCS2.Migrations
{
    /// <inheritdoc />
    public partial class intialAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c3c823c-01cc-41d5-b84c-fee525a6605a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94cac02c-cfd7-471d-98c2-b6cb4a68f8aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad1bb794-7571-4f22-a910-efcbfc9e0c51");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c35a983-9a42-4ccc-b0c2-1fac24e5a40e", "e5fd6c0c-9c90-4f85-8cbb-1055765ffdcb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c35a983-9a42-4ccc-b0c2-1fac24e5a40e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5fd6c0c-9c90-4f85-8cbb-1055765ffdcb");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3c35a983-9a42-4ccc-b0c2-1fac24e5a40e", null, "SuperUser", "SUPERUSER" },
                    { "3c3c823c-01cc-41d5-b84c-fee525a6605a", null, "Lecturer", "LECTURER" },
                    { "94cac02c-cfd7-471d-98c2-b6cb4a68f8aa", null, "Manager", "MANAGER" },
                    { "ad1bb794-7571-4f22-a910-efcbfc9e0c51", null, "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e5fd6c0c-9c90-4f85-8cbb-1055765ffdcb", 0, "c524fb38-c65c-43d1-b5e0-efc906e3d4e8", "admin@yourapp.com", true, false, null, "Admin", "ADMIN@YOURAPP.COM", "ADMIN@YOURAPP.COM", "AQAAAAIAAYagAAAAECyZN9bYHt1nKn2/NLZlZYkKWiDNLMcCcWOtUcZUVYeiCbjq5+gtb+NovJNnMDwclg==", null, false, "f4117e87-6501-4248-94ed-a11635a76842", "User", false, "admin@yourapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3c35a983-9a42-4ccc-b0c2-1fac24e5a40e", "e5fd6c0c-9c90-4f85-8cbb-1055765ffdcb" });
        }
    }
}
