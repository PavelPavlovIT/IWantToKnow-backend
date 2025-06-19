using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_new_typetests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "TypeTests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "190269c0-b7c4-479f-8bd2-a2f705f22956", "Exam (speak on medium level)" },
                    { "1928f7d7-225f-4c32-b3f8-4786dc3dffee", "Study (speak on medium level)" },
                    { "25d763ee-7229-467a-84cc-4dacffe1a8ff", "Exam (speak on easy level)" },
                    { "2b8e0d25-349c-4015-8edb-28e57a77b73a", "Test (speak on medium level)" },
                    { "48765e9e-b029-4011-a4fb-794687e208f5", "Test (speak on easy level)" },
                    { "7b4da4cf-52b5-4c78-9834-b56e9dbe491a", "Exam (listening)" },
                    { "80907d2b-8387-4d4d-b7d6-1bc7d617d1bb", "Study (speak on easy level)" },
                    { "903bf213-5854-46c4-a73c-e2657be47f13", "Test (reading)" },
                    { "930c9e4a-60cc-462a-9b4a-0f2e6b263932", "Study (speak on difficult level)" },
                    { "9f8fb08c-0074-4860-8a95-6f49ab6bf5ac", "Exam (reading)" },
                    { "ceebb9d6-8bbe-4f68-8c81-aefd6b78a98e", "Exam (speak on difficult level)" },
                    { "e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0", "Exam (speak on difficult level)" },
                    { "f237af31-884e-4c25-a8b1-8206abebee50", "Test (listening)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "190269c0-b7c4-479f-8bd2-a2f705f22956");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "1928f7d7-225f-4c32-b3f8-4786dc3dffee");

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

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "7b4da4cf-52b5-4c78-9834-b56e9dbe491a");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "80907d2b-8387-4d4d-b7d6-1bc7d617d1bb");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "903bf213-5854-46c4-a73c-e2657be47f13");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "930c9e4a-60cc-462a-9b4a-0f2e6b263932");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "9f8fb08c-0074-4860-8a95-6f49ab6bf5ac");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "ceebb9d6-8bbe-4f68-8c81-aefd6b78a98e");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0");

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
    }
}
