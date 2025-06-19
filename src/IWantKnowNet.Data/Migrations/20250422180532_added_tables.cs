using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedStudyQuestions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "190e0aea-cfed-4247-9a0f-551182cfe175");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5283e283-4d8e-4c13-9383-5a12c203657e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798b7f51-1d77-40b2-98c2-16a79695104d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c33dd20b-67e8-4e0c-b19a-bc4b6a52ff9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da93398f-7d0c-40cf-879e-58b5b79f5067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fedc47a8-4967-4e33-a037-75161090f962");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestionsByRead",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionsByRead", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b38d6fd-bdd9-458f-95b9-98b73c149c51", null, "ApplicationRole", "User", null },
                    { "3d64a1ea-7b0a-4489-bc41-45d14d5f1977", null, "ApplicationRole", "Manager", null },
                    { "3f16c265-45b7-42f2-9606-e0a451564e7b", null, "ApplicationRole", "Owner", null },
                    { "b0550be5-3cf8-4673-aa06-a066f178a076", null, "ApplicationRole", "MentorLevel_1", null },
                    { "f826976a-7bc2-457c-9633-4304a93db53e", null, "ApplicationRole", "StudentLevel_1", null },
                    { "f9654d0e-5721-4345-853f-f787e4de7f2a", null, "ApplicationRole", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "775e1904-0927-4add-bc36-3fd0484b1a2f", "3cdda2d7-2f83-4489-a6c3-0d232c4440f8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionsByRead");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b38d6fd-bdd9-458f-95b9-98b73c149c51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d64a1ea-7b0a-4489-bc41-45d14d5f1977");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f16c265-45b7-42f2-9606-e0a451564e7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0550be5-3cf8-4673-aa06-a066f178a076");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f826976a-7bc2-457c-9633-4304a93db53e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9654d0e-5721-4345-853f-f787e4de7f2a");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "190e0aea-cfed-4247-9a0f-551182cfe175", null, "ApplicationRole", "MentorLevel_1", null },
                    { "5283e283-4d8e-4c13-9383-5a12c203657e", null, "ApplicationRole", "Admin", null },
                    { "798b7f51-1d77-40b2-98c2-16a79695104d", null, "ApplicationRole", "Manager", null },
                    { "c33dd20b-67e8-4e0c-b19a-bc4b6a52ff9d", null, "ApplicationRole", "Owner", null },
                    { "da93398f-7d0c-40cf-879e-58b5b79f5067", null, "ApplicationRole", "StudentLevel_1", null },
                    { "fedc47a8-4967-4e33-a037-75161090f962", null, "ApplicationRole", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d12d32af-867e-4b46-b9de-3a10322e13f1", "1fd240ef-c0d2-4df6-96e9-98e8f42725f1" });
        }
    }
}
