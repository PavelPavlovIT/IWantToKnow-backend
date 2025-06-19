using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_study_tytests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "TypeTests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2c4286c2-a0f5-4a72-861c-12829546981b", "Study (listening)" },
                    { "dbf39bef-b195-48c8-b328-d1087e085e18", "Study (reading)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "2c4286c2-a0f5-4a72-861c-12829546981b");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "dbf39bef-b195-48c8-b328-d1087e085e18");

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
        }
    }
}
