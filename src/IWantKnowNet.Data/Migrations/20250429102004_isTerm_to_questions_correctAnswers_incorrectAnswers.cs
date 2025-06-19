using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class isTerm_to_questions_correctAnswers_incorrectAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsTerm",
                table: "Questions",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Payments",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime");

            migrationBuilder.AddColumn<bool>(
                name: "IsTerm",
                table: "IncorrectAnswers",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "147a3ec6-4184-4f71-9839-ed998ded6539", null, "ApplicationRole", "MentorLevel_1", null },
                    { "155be43b-0b40-49b8-b799-e803e4f66e79", null, "ApplicationRole", "StudentLevel_1", null },
                    { "1f1bef0b-6541-4daa-a3e7-8b9bbcf0d126", null, "ApplicationRole", "Manager", null },
                    { "b470ac5c-f6b7-4e34-a256-ce46dcea3999", null, "ApplicationRole", "Admin", null },
                    { "dbe26eb4-27d4-45f3-886e-817f8a1d8ccf", null, "ApplicationRole", "Owner", null },
                    { "e3e04283-64d8-4a90-8897-786c3dd979ac", null, "ApplicationRole", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "83a37c96-e313-4f42-bbbe-b09ca24b6bbe", "060635e0-e92a-4351-a0f0-e4e72cbd3d15" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "147a3ec6-4184-4f71-9839-ed998ded6539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "155be43b-0b40-49b8-b799-e803e4f66e79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f1bef0b-6541-4daa-a3e7-8b9bbcf0d126");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b470ac5c-f6b7-4e34-a256-ce46dcea3999");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe26eb4-27d4-45f3-886e-817f8a1d8ccf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3e04283-64d8-4a90-8897-786c3dd979ac");

            migrationBuilder.DropColumn(
                name: "IsTerm",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsTerm",
                table: "IncorrectAnswers");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Created",
                table: "Payments",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4f7e1bcd-2f71-40cf-8193-e5da5210c9dc", "36a05092-ac46-42fd-b446-0e783319b81e" });
        }
    }
}
