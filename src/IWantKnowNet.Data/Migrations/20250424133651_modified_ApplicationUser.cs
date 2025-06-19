using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class modified_ApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "044415f1-1a1e-4f9d-915d-02b036b8c272");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08f01e96-a531-4c63-b668-1f5e0ade6b1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22908f3f-cb00-42d6-9a3d-7883818fee14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46472b46-6126-410e-83af-9f21cc9b9fd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ad817e-8170-42f0-83c9-3c46876795e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bbe90d4-e182-4e85-9a70-c2dc4f3f1230");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDateTime",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "492898af-db21-4012-a3b1-4a8b745d6540", null, "ApplicationRole", "Manager", null },
                    { "519fe4a6-cd21-4255-9413-1209636aa045", null, "ApplicationRole", "Admin", null },
                    { "900ffa1c-c1fc-4453-987c-d55b55b0e4f6", null, "ApplicationRole", "StudentLevel_1", null },
                    { "c64d9158-e607-468b-8642-c2cce90293a5", null, "ApplicationRole", "Owner", null },
                    { "e51efd85-92ef-4238-be8b-a66450ea8d15", null, "ApplicationRole", "MentorLevel_1", null },
                    { "fb101a00-cd29-4e1e-8861-3cc74b3f9333", null, "ApplicationRole", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "ExpireDateTime", "SecurityStamp" },
                values: new object[] { "4f7e1bcd-2f71-40cf-8193-e5da5210c9dc", null, "36a05092-ac46-42fd-b446-0e783319b81e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492898af-db21-4012-a3b1-4a8b745d6540");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "519fe4a6-cd21-4255-9413-1209636aa045");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "900ffa1c-c1fc-4453-987c-d55b55b0e4f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c64d9158-e607-468b-8642-c2cce90293a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e51efd85-92ef-4238-be8b-a66450ea8d15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb101a00-cd29-4e1e-8861-3cc74b3f9333");

            migrationBuilder.DropColumn(
                name: "ExpireDateTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "044415f1-1a1e-4f9d-915d-02b036b8c272", null, "ApplicationRole", "StudentLevel_1", null },
                    { "08f01e96-a531-4c63-b668-1f5e0ade6b1d", null, "ApplicationRole", "Manager", null },
                    { "22908f3f-cb00-42d6-9a3d-7883818fee14", null, "ApplicationRole", "MentorLevel_1", null },
                    { "46472b46-6126-410e-83af-9f21cc9b9fd3", null, "ApplicationRole", "User", null },
                    { "87ad817e-8170-42f0-83c9-3c46876795e6", null, "ApplicationRole", "Owner", null },
                    { "8bbe90d4-e182-4e85-9a70-c2dc4f3f1230", null, "ApplicationRole", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ac98ab6-e560-477e-b92a-b291f9943131", "bea1bf1d-666a-4ed8-b58f-31d10314876c" });
        }
    }
}
