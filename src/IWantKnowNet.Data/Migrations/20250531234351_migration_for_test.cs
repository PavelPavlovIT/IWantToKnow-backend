using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class migration_for_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
