using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_reverse_to_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Reverse",
                table: "Categories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "236cd8ae-16cd-4ece-a92a-24b8aea42b0f", null, "ApplicationRole", "User", null },
                    { "58c55e46-262d-485f-8873-21588a192377", null, "ApplicationRole", "Admin", null },
                    { "74b92ebb-d004-4930-a355-fcc0f7d7594d", null, "ApplicationRole", "Owner", null },
                    { "c26fa534-253b-4225-9a87-5345be7513db", null, "ApplicationRole", "MentorLevel_1", null },
                    { "dbdc7038-c63f-48f4-9ff1-9821480e092c", null, "ApplicationRole", "Manager", null },
                    { "e8604373-3894-4c89-af56-cc56be035a13", null, "ApplicationRole", "StudentLevel_1", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c3b99e2c-87dc-407f-be01-112a5d64205c", "2e77a69b-7a4d-4693-997d-b9b024160aaa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "236cd8ae-16cd-4ece-a92a-24b8aea42b0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58c55e46-262d-485f-8873-21588a192377");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74b92ebb-d004-4930-a355-fcc0f7d7594d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c26fa534-253b-4225-9a87-5345be7513db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbdc7038-c63f-48f4-9ff1-9821480e092c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8604373-3894-4c89-af56-cc56be035a13");

            migrationBuilder.DropColumn(
                name: "Reverse",
                table: "Categories");

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
    }
}
