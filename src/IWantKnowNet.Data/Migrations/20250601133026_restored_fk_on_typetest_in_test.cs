using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class restored_fk_on_typetest_in_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04e8ef96-f8b8-4399-a0b5-e65d3c757025");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06a430b6-bc3f-40c7-92dc-5e78cd53c74c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e0af800-5f0d-46c0-903e-23127ecbd6d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e2ea841-eafd-40b5-8fde-4d6363f4e134");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "925d2be3-a2ad-4119-9c0f-21bf8a4841a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fac23ea2-2e0d-4a51-8620-e6285d227521");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "364d57e4-0cf0-4691-8b66-2968929c46e9", null, "ApplicationRole", "Owner", null },
                    { "74a3d23c-e345-4cb7-8855-01d5c6560c61", null, "ApplicationRole", "StudentLevel_1", null },
                    { "9de2562e-13a3-42b3-bd38-cce4b29163d6", null, "ApplicationRole", "Manager", null },
                    { "b28f8a00-2443-4b19-a5e7-e30af46d8876", null, "ApplicationRole", "User", null },
                    { "d7f306ff-0204-44a4-afc1-166aa983563d", null, "ApplicationRole", "Admin", null },
                    { "fac049b3-b9f7-43ef-a8cb-456f5b2824e7", null, "ApplicationRole", "MentorLevel_1", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "07952982-4f5a-4752-a23e-803ad2886979", "b5f7648a-6a87-4559-84ee-fb4820bceeb4" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "364d57e4-0cf0-4691-8b66-2968929c46e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a3d23c-e345-4cb7-8855-01d5c6560c61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9de2562e-13a3-42b3-bd38-cce4b29163d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b28f8a00-2443-4b19-a5e7-e30af46d8876");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7f306ff-0204-44a4-afc1-166aa983563d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fac049b3-b9f7-43ef-a8cb-456f5b2824e7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04e8ef96-f8b8-4399-a0b5-e65d3c757025", null, "ApplicationRole", "Admin", null },
                    { "06a430b6-bc3f-40c7-92dc-5e78cd53c74c", null, "ApplicationRole", "Owner", null },
                    { "0e0af800-5f0d-46c0-903e-23127ecbd6d5", null, "ApplicationRole", "StudentLevel_1", null },
                    { "1e2ea841-eafd-40b5-8fde-4d6363f4e134", null, "ApplicationRole", "User", null },
                    { "925d2be3-a2ad-4119-9c0f-21bf8a4841a7", null, "ApplicationRole", "MentorLevel_1", null },
                    { "fac23ea2-2e0d-4a51-8620-e6285d227521", null, "ApplicationRole", "Manager", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e1b52128-e9a6-4846-9ab0-3051846ee234", "f8ba6b2c-38d4-4479-9ed4-87e02bcffbd8" });
        }
    }
}
