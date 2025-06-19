using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class removed_fk_on_typetest_in_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_TypeTests_TypeTestId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_TypeTestId",
                table: "Tests");

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

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "25d763ee-7229-467a-84cc-4dacffe1a8ff");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "2cf853d6-c33a-402f-9e18-5a4e904e5fad");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "33ec0a13-cda5-4286-86c7-73eae18dd762");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "7b4da4cf-52b5-4c78-9834-b56e9dbe491a");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "903bf213-5854-46c4-a73c-e2657be47f13");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "9f8fb08c-0074-4860-8a95-6f49ab6bf5ac");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "ac6a1d9c-6eff-40a0-a0d3-02784b4cc804");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "f237af31-884e-4c25-a8b1-8206abebee50");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50b108f5-f2e2-4722-83eb-9c5983828882", null, "ApplicationRole", "MentorLevel_1", null },
                    { "594dc3d7-8401-4729-be9f-aecd303f9faf", null, "ApplicationRole", "Owner", null },
                    { "857f9d7b-ca0c-4ae5-9737-9d2e3e5a8d05", null, "ApplicationRole", "Admin", null },
                    { "85ad6c65-2d38-4595-8dda-0cb6a0891eee", null, "ApplicationRole", "Manager", null },
                    { "8c0e7e3d-4fd5-4d3e-9f2b-2dbcd7e72e14", null, "ApplicationRole", "User", null },
                    { "df83b22c-86fa-4083-8a53-79c777bb0ee6", null, "ApplicationRole", "StudentLevel_1", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff87035f-29d3-4ba7-a9bc-8b167745a41e", "aee5dc47-cdad-4338-80c3-ddbab3bebf03" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50b108f5-f2e2-4722-83eb-9c5983828882");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "594dc3d7-8401-4729-be9f-aecd303f9faf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "857f9d7b-ca0c-4ae5-9737-9d2e3e5a8d05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85ad6c65-2d38-4595-8dda-0cb6a0891eee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c0e7e3d-4fd5-4d3e-9f2b-2dbcd7e72e14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df83b22c-86fa-4083-8a53-79c777bb0ee6");

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

            migrationBuilder.InsertData(
                table: "TypeTests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "25d763ee-7229-467a-84cc-4dacffe1a8ff", "Exam (speak)" },
                    { "2cf853d6-c33a-402f-9e18-5a4e904e5fad", "WorkOnMistakes" },
                    { "33ec0a13-cda5-4286-86c7-73eae18dd762", "Training" },
                    { "7b4da4cf-52b5-4c78-9834-b56e9dbe491a", "Exam by group (listening)" },
                    { "903bf213-5854-46c4-a73c-e2657be47f13", "Exam on the topic (reading)" },
                    { "9f8fb08c-0074-4860-8a95-6f49ab6bf5ac", "Exam by group (reading)" },
                    { "ac6a1d9c-6eff-40a0-a0d3-02784b4cc804", "AssignTest" },
                    { "f237af31-884e-4c25-a8b1-8206abebee50", "Exam on the topic (listening)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TypeTestId",
                table: "Tests",
                column: "TypeTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_TypeTests_TypeTestId",
                table: "Tests",
                column: "TypeTestId",
                principalTable: "TypeTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
