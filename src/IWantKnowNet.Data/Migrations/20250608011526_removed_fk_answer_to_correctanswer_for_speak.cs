using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class removed_fk_answer_to_correctanswer_for_speak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_CorrectAnswers_CorrectAnswerId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_CorrectAnswerId",
                table: "Answers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "183551e6-a2a4-4c88-8385-1af5673f86db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20f96781-3b59-42d7-9323-53bda10b06ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c834736-27f6-41ae-8f7f-9fd0622d7f5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98070f88-7a32-42d8-a447-c5f52e4e4a11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e799d077-9af1-473f-ad43-7e7146896f62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f82b887a-5f03-4ca6-a117-49779e1b2e52");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "190269c0-b7c4-479f-8bd2-a2f705f22956");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "25d763ee-7229-467a-84cc-4dacffe1a8ff");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "2b8e0d25-349c-4015-8edb-28e57a77b73a");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "48765e9e-b029-4011-a4fb-794687e208f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04ddd2e6-6c24-4d7f-a8ef-a126692fcb56", null, "ApplicationRole", "MentorLevel_1", null },
                    { "1b929346-9bc1-4879-b9a2-a3f8388eb2b7", null, "ApplicationRole", "Owner", null },
                    { "2d598e77-8d6f-4dce-b015-83ce3fda4f14", null, "ApplicationRole", "User", null },
                    { "78f3ef56-7be3-493d-8fcf-a3e6bc284ad9", null, "ApplicationRole", "Manager", null },
                    { "bda37d06-f980-4635-bf9c-0a5cdbabd9ac", null, "ApplicationRole", "StudentLevel_1", null },
                    { "d86c120c-60c2-4641-bd08-772734f6cdcd", null, "ApplicationRole", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "95b3aae9-6067-4a17-bac1-2c835f91ae43", "4344b320-0f23-4740-9e87-d2cb63a9151f" });

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "a0165e11-bfcf-42e2-8e36-79f507097d0f",
                column: "Name",
                value: "Test (speaking)");

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0",
                column: "Name",
                value: "Exam (speaking)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04ddd2e6-6c24-4d7f-a8ef-a126692fcb56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b929346-9bc1-4879-b9a2-a3f8388eb2b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d598e77-8d6f-4dce-b015-83ce3fda4f14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78f3ef56-7be3-493d-8fcf-a3e6bc284ad9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda37d06-f980-4635-bf9c-0a5cdbabd9ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86c120c-60c2-4641-bd08-772734f6cdcd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "183551e6-a2a4-4c88-8385-1af5673f86db", null, "ApplicationRole", "StudentLevel_1", null },
                    { "20f96781-3b59-42d7-9323-53bda10b06ae", null, "ApplicationRole", "MentorLevel_1", null },
                    { "2c834736-27f6-41ae-8f7f-9fd0622d7f5e", null, "ApplicationRole", "Owner", null },
                    { "98070f88-7a32-42d8-a447-c5f52e4e4a11", null, "ApplicationRole", "User", null },
                    { "e799d077-9af1-473f-ad43-7e7146896f62", null, "ApplicationRole", "Manager", null },
                    { "f82b887a-5f03-4ca6-a117-49779e1b2e52", null, "ApplicationRole", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf9c7896-d742-4ae5-a8de-2f78db2fddad", "9aa27190-f35f-42cb-80f9-f0a0f69605c4" });

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "a0165e11-bfcf-42e2-8e36-79f507097d0f",
                column: "Name",
                value: "Test (speak on difficult level)");

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0",
                column: "Name",
                value: "Exam (speak on difficult level)");

            migrationBuilder.InsertData(
                table: "TypeTests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "190269c0-b7c4-479f-8bd2-a2f705f22956", "Exam (speak on medium level)" },
                    { "25d763ee-7229-467a-84cc-4dacffe1a8ff", "Exam (speak on easy level)" },
                    { "2b8e0d25-349c-4015-8edb-28e57a77b73a", "Test (speak on medium level)" },
                    { "48765e9e-b029-4011-a4fb-794687e208f5", "Test (speak on easy level)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CorrectAnswerId",
                table: "Answers",
                column: "CorrectAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_CorrectAnswers_CorrectAnswerId",
                table: "Answers",
                column: "CorrectAnswerId",
                principalTable: "CorrectAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
