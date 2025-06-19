using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class removed_tables_for_speak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionBySpeak_1");

            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionBySpeak_2");

            migrationBuilder.DropTable(
                name: "CompletedStudyQuestionBySpeak_3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "153c4d31-14c8-431e-96de-de14817cc31d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2622a701-8b26-4a3a-9c56-9579b4ab31ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3356ee9f-8cc5-4b81-9935-7e8e051f7ecf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ce1c8fa-301a-4c80-861c-0cd75e694c53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6afa1c1e-e32e-42df-b6e0-dcd651ba5122");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3e30aab-2984-4cf5-8464-e15ed1a12379");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CompletedStudyQuestionBySpeak_1",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionBySpeak_1", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestionBySpeak_2",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionBySpeak_2", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestionBySpeak_3",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestionBySpeak_3", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "153c4d31-14c8-431e-96de-de14817cc31d", null, "ApplicationRole", "MentorLevel_1", null },
                    { "2622a701-8b26-4a3a-9c56-9579b4ab31ec", null, "ApplicationRole", "StudentLevel_1", null },
                    { "3356ee9f-8cc5-4b81-9935-7e8e051f7ecf", null, "ApplicationRole", "User", null },
                    { "3ce1c8fa-301a-4c80-861c-0cd75e694c53", null, "ApplicationRole", "Manager", null },
                    { "6afa1c1e-e32e-42df-b6e0-dcd651ba5122", null, "ApplicationRole", "Owner", null },
                    { "f3e30aab-2984-4cf5-8464-e15ed1a12379", null, "ApplicationRole", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a437922-0b9f-4504-9f2b-ad99e3f71eaa", "c8547246-913f-47c9-8f5c-df4932400486" });
        }
    }
}
