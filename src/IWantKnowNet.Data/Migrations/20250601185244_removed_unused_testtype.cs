using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class removed_unused_testtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "067146b5-76ac-4a25-8233-d5e9502fa230");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "533f9e93-debe-4aa5-97d6-6b0af3a3481f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "748e7fc3-3ed3-46d6-8dba-c6502bbe219b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf67ae17-7599-435f-bf0e-11b3783797be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2f6eeff-fee7-4b30-b6e2-e37ce2727659");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b0194e-7909-473d-93fc-b0baa6521cc0");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "ceebb9d6-8bbe-4f68-8c81-aefd6b78a98e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "322292ce-05f1-49dd-918b-82bf33a83db2", null, "ApplicationRole", "MentorLevel_1", null },
                    { "62f093e4-fccb-4e09-ae37-c3adada0ae01", null, "ApplicationRole", "Admin", null },
                    { "9f8447b1-5d9a-49fd-bc8b-99420e6a2a1c", null, "ApplicationRole", "StudentLevel_1", null },
                    { "a7338447-774f-4ade-ba17-f66aa77d947a", null, "ApplicationRole", "Owner", null },
                    { "f06dfc31-19ad-4f42-94c5-60614a816726", null, "ApplicationRole", "Manager", null },
                    { "f8104fb4-91a6-4881-b02b-5a9993b07a3c", null, "ApplicationRole", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62d6eedd-6115-4594-a30f-24d02847b7b6", "a193b230-6267-4f5b-b67e-7ed20406b041" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322292ce-05f1-49dd-918b-82bf33a83db2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62f093e4-fccb-4e09-ae37-c3adada0ae01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f8447b1-5d9a-49fd-bc8b-99420e6a2a1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7338447-774f-4ade-ba17-f66aa77d947a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f06dfc31-19ad-4f42-94c5-60614a816726");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8104fb4-91a6-4881-b02b-5a9993b07a3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "067146b5-76ac-4a25-8233-d5e9502fa230", null, "ApplicationRole", "Admin", null },
                    { "533f9e93-debe-4aa5-97d6-6b0af3a3481f", null, "ApplicationRole", "StudentLevel_1", null },
                    { "748e7fc3-3ed3-46d6-8dba-c6502bbe219b", null, "ApplicationRole", "MentorLevel_1", null },
                    { "cf67ae17-7599-435f-bf0e-11b3783797be", null, "ApplicationRole", "User", null },
                    { "e2f6eeff-fee7-4b30-b6e2-e37ce2727659", null, "ApplicationRole", "Manager", null },
                    { "f9b0194e-7909-473d-93fc-b0baa6521cc0", null, "ApplicationRole", "Owner", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a62a9e08-49c9-4d7b-ac60-8d553574e2e4", "b12509c7-40b9-4dce-911d-70860ace7abc" });

            migrationBuilder.InsertData(
                table: "TypeTests",
                columns: new[] { "Id", "Name" },
                values: new object[] { "ceebb9d6-8bbe-4f68-8c81-aefd6b78a98e", "Exam (speak on difficult level)" });
        }
    }
}
