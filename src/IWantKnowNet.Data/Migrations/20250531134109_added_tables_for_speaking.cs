using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_tables_for_speaking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestionBySpeak_1",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false)
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
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false)
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
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false)
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
                    { "2883aa62-59e2-4617-90ab-9b690bd1abc4", null, "ApplicationRole", "Admin", null },
                    { "32ae0b6a-01bc-461e-ae6f-51c62e561988", null, "ApplicationRole", "Owner", null },
                    { "b812713a-1c01-4579-a194-ab119f9bb5ea", null, "ApplicationRole", "User", null },
                    { "bddd7f72-7d93-494e-a153-5a253c088301", null, "ApplicationRole", "StudentLevel_1", null },
                    { "c848160d-0b95-4b42-a219-11caf3dda7cd", null, "ApplicationRole", "MentorLevel_1", null },
                    { "cd31dd25-15bd-4837-a313-9afa01fa8e2e", null, "ApplicationRole", "Manager", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4aa417fe-9c30-459f-9a15-6e3984215a70", "d06e6c2f-a889-417c-8b1b-aae756bb167d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "2883aa62-59e2-4617-90ab-9b690bd1abc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32ae0b6a-01bc-461e-ae6f-51c62e561988");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b812713a-1c01-4579-a194-ab119f9bb5ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bddd7f72-7d93-494e-a153-5a253c088301");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c848160d-0b95-4b42-a219-11caf3dda7cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd31dd25-15bd-4837-a313-9afa01fa8e2e");

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
    }
}
