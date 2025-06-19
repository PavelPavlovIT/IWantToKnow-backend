using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class modified_isTerm_to_questions_correctAnswers_incorrectAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e82a07c-c321-4047-966e-5fdce0609194");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21a5c78e-8039-431a-b71c-49e326913adf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3493639c-fd66-4479-a2dd-ce93da7c1826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a97e155b-faaa-47f4-801e-720f1897ee2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc207f85-d288-4906-855b-dd12507f0253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5e33d54-c073-4aff-9e26-a020d97e5a09");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "Questions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "IncorrectAnswers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "CorrectAnswers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "Questions",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "IncorrectAnswers",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTerm",
                table: "CorrectAnswers",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e82a07c-c321-4047-966e-5fdce0609194", null, "ApplicationRole", "Admin", null },
                    { "21a5c78e-8039-431a-b71c-49e326913adf", null, "ApplicationRole", "User", null },
                    { "3493639c-fd66-4479-a2dd-ce93da7c1826", null, "ApplicationRole", "StudentLevel_1", null },
                    { "a97e155b-faaa-47f4-801e-720f1897ee2a", null, "ApplicationRole", "MentorLevel_1", null },
                    { "bc207f85-d288-4906-855b-dd12507f0253", null, "ApplicationRole", "Owner", null },
                    { "c5e33d54-c073-4aff-9e26-a020d97e5a09", null, "ApplicationRole", "Manager", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "06dfb214-a59e-43c4-9738-c62cdb250e57", "03ea1ae9-2ba0-4e4e-b5bd-72a5d0bba2f9" });
        }
    }
}
