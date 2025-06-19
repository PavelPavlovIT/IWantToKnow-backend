using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_new_testtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3448f07e-d525-4a2b-a51f-06eef4f7521f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cf2b17c-5dfb-4f7c-9ea4-0af1b458db57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b66b405e-265a-432c-8e8d-ed11e602fbfc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cacbde-82a3-4eff-9aa8-fdfeff260295");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e99c9d59-645e-406e-8e1d-61cb33b200ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f14ffffe-00a2-49f9-9b2b-0accab11e264");

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
                values: new object[] { "a0165e11-bfcf-42e2-8e36-79f507097d0f", "Test (speak on difficult level)" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "a0165e11-bfcf-42e2-8e36-79f507097d0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3448f07e-d525-4a2b-a51f-06eef4f7521f", null, "ApplicationRole", "User", null },
                    { "8cf2b17c-5dfb-4f7c-9ea4-0af1b458db57", null, "ApplicationRole", "MentorLevel_1", null },
                    { "b66b405e-265a-432c-8e8d-ed11e602fbfc", null, "ApplicationRole", "Admin", null },
                    { "b6cacbde-82a3-4eff-9aa8-fdfeff260295", null, "ApplicationRole", "Owner", null },
                    { "e99c9d59-645e-406e-8e1d-61cb33b200ad", null, "ApplicationRole", "StudentLevel_1", null },
                    { "f14ffffe-00a2-49f9-9b2b-0accab11e264", null, "ApplicationRole", "Manager", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66a549d0-2bdc-4542-9811-4f16c7ede72b", "704cad86-9a79-460c-8442-d24f750e13e2" });
        }
    }
}
