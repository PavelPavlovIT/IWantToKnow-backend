using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_tables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "CompletedStudyQuestionsByListen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionsByListen", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionsByListen");

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
    }
}
