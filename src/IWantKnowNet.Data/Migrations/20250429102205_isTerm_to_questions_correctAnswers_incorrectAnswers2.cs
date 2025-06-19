using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class isTerm_to_questions_correctAnswers_incorrectAnswers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsTerm",
                table: "CorrectAnswers",
                type: "tinyint(1)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsTerm",
                table: "CorrectAnswers");

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
    }
}
