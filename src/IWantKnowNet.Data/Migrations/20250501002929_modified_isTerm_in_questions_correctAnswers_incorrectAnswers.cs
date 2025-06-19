using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class modified_isTerm_in_questions_correctAnswers_incorrectAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6abb1aef-ced1-45fa-adc7-6cc5e7b1ad3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "758cc5e2-2114-4986-a2a2-576e828a88b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92e92521-19c3-4700-93ab-91fa2e4b43d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8b54739-49aa-4d08-8b79-82d5401e42bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c17f1515-8020-43b5-afb1-6a12cc7900ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc45993-b474-4477-9009-f284071224ed");

            migrationBuilder.AlterColumn<int>(
                name: "IsTerm",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<int>(
                name: "IsTerm",
                table: "IncorrectAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<int>(
                name: "IsTerm",
                table: "CorrectAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "Questions",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "IncorrectAnswers",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "CorrectAnswers",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6abb1aef-ced1-45fa-adc7-6cc5e7b1ad3a", null, "ApplicationRole", "User", null },
                    { "758cc5e2-2114-4986-a2a2-576e828a88b7", null, "ApplicationRole", "Owner", null },
                    { "92e92521-19c3-4700-93ab-91fa2e4b43d0", null, "ApplicationRole", "Admin", null },
                    { "a8b54739-49aa-4d08-8b79-82d5401e42bf", null, "ApplicationRole", "MentorLevel_1", null },
                    { "c17f1515-8020-43b5-afb1-6a12cc7900ce", null, "ApplicationRole", "Manager", null },
                    { "dcc45993-b474-4477-9009-f284071224ed", null, "ApplicationRole", "StudentLevel_1", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a90e8dc9-e6e4-4f8d-b47b-4aee643e93e7", "2ec1cae2-2057-4830-9bae-5d2e67166b56" });
        }
    }
}
