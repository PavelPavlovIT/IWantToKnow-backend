using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_tables_for_speak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09776411-73cd-42f6-853f-9a6238d58585");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "198add8a-9cda-4d34-a74f-3f33bab55cd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24f827b1-a60f-4116-871b-bfad3cc6b22b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6974a883-e1a9-4d51-bcee-9ae1dbe9deff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a51c13f-4009-4888-9d05-56e5e057afe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f6882c-ad6e-4bbe-9fa4-9ce384fdbc35");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestionsBySpeakDifficultLevel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionsBySpeakDifficultLevel", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestionsBySpeakEasyLevel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionsBySpeakEasyLevel", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestionsBySpeakMediumLevel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionsBySpeakMediumLevel", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dd6278e-4d81-443a-80b1-b612105e4db1", null, "ApplicationRole", "StudentLevel_1", null },
                    { "17d84ef2-896f-4fac-990e-d99d8ea1e7d6", null, "ApplicationRole", "MentorLevel_1", null },
                    { "631ae1e3-c31c-4c0c-9a92-285c64919264", null, "ApplicationRole", "User", null },
                    { "70496f99-6836-43f3-91d9-8f8825c01153", null, "ApplicationRole", "Manager", null },
                    { "db321d91-7e17-4f53-8eb1-1e41e93c12e7", null, "ApplicationRole", "Owner", null },
                    { "f18d29a3-f99f-4d9f-a0df-c5f024ce6177", null, "ApplicationRole", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b8cf42d-904b-4c2d-bfa2-2ef53b93abba", "62300021-1a96-48c3-b4d0-34fa4b826cc7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionsBySpeakDifficultLevel");

            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionsBySpeakEasyLevel");

            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionsBySpeakMediumLevel");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dd6278e-4d81-443a-80b1-b612105e4db1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d84ef2-896f-4fac-990e-d99d8ea1e7d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "631ae1e3-c31c-4c0c-9a92-285c64919264");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70496f99-6836-43f3-91d9-8f8825c01153");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db321d91-7e17-4f53-8eb1-1e41e93c12e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18d29a3-f99f-4d9f-a0df-c5f024ce6177");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09776411-73cd-42f6-853f-9a6238d58585", null, "ApplicationRole", "StudentLevel_1", null },
                    { "198add8a-9cda-4d34-a74f-3f33bab55cd6", null, "ApplicationRole", "Manager", null },
                    { "24f827b1-a60f-4116-871b-bfad3cc6b22b", null, "ApplicationRole", "User", null },
                    { "6974a883-e1a9-4d51-bcee-9ae1dbe9deff", null, "ApplicationRole", "Admin", null },
                    { "9a51c13f-4009-4888-9d05-56e5e057afe0", null, "ApplicationRole", "MentorLevel_1", null },
                    { "f5f6882c-ad6e-4bbe-9fa4-9ce384fdbc35", null, "ApplicationRole", "Owner", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "456f2915-58c7-42bd-bda3-1cac5b53263d", "06e80491-ec8d-4123-948a-fa0aded90756" });
        }
    }
}
