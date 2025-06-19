using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class modified_ApplicationUser_changed_language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d18be90-e26c-4261-b290-268f1f9da149");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43e6688b-3ef8-4ab7-a070-fd367882ad43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57323fac-aeef-46d7-b066-1ff4ab19a778");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6affa4af-32be-4829-b007-64b93feb58d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d701ad-1dd2-4e05-a932-f77e53e07a29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f95816d8-9655-46ad-966e-44cea77e21db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03a0acd9-d30d-49e9-98b9-9b5f5c3637a8", null, "ApplicationRole", "Manager", null },
                    { "1f8d8410-e326-486e-b9a0-7bf3bd7a99c7", null, "ApplicationRole", "StudentLevel_1", null },
                    { "893847a5-951c-481e-b66b-1895d70d9d5f", null, "ApplicationRole", "Owner", null },
                    { "e4ebdfb6-e5a2-4a60-8814-76230d36e0f4", null, "ApplicationRole", "MentorLevel_1", null },
                    { "e65a2030-521e-4531-bfd6-0c18977ad186", null, "ApplicationRole", "Admin", null },
                    { "ff76de1d-6d1e-4bec-946f-55b8e550202f", null, "ApplicationRole", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "feebac14-2c39-424b-a9cd-2a459eef3117", "004c7b2c-97bb-4175-b1ac-05bdb4a549ab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03a0acd9-d30d-49e9-98b9-9b5f5c3637a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f8d8410-e326-486e-b9a0-7bf3bd7a99c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "893847a5-951c-481e-b66b-1895d70d9d5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4ebdfb6-e5a2-4a60-8814-76230d36e0f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e65a2030-521e-4531-bfd6-0c18977ad186");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff76de1d-6d1e-4bec-946f-55b8e550202f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d18be90-e26c-4261-b290-268f1f9da149", null, "ApplicationRole", "MentorLevel_1", null },
                    { "43e6688b-3ef8-4ab7-a070-fd367882ad43", null, "ApplicationRole", "Admin", null },
                    { "57323fac-aeef-46d7-b066-1ff4ab19a778", null, "ApplicationRole", "Owner", null },
                    { "6affa4af-32be-4829-b007-64b93feb58d3", null, "ApplicationRole", "StudentLevel_1", null },
                    { "e5d701ad-1dd2-4e05-a932-f77e53e07a29", null, "ApplicationRole", "Manager", null },
                    { "f95816d8-9655-46ad-966e-44cea77e21db", null, "ApplicationRole", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b7a80ae-699b-486e-a15b-0c2d50f0b688", "bbe67a05-0e52-426b-869f-affc398809a5" });
        }
    }
}
