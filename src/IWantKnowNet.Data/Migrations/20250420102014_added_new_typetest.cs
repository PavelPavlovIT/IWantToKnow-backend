using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_new_typetest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a290569-c08d-4880-8e96-ea04e8e68edf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cc1147b-4d82-4ba9-8390-68078f1e39c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2e4e2a1-49fa-4d35-aa66-626ac6b55b57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfd082ae-6c5f-4de1-a229-595e41a8ccab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f72d5c87-a99c-4a6f-b211-ba5b00492e29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa872ab8-b22e-4c29-b942-ef03d3e3d1df");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "190e0aea-cfed-4247-9a0f-551182cfe175", null, "ApplicationRole", "MentorLevel_1", null },
                    { "5283e283-4d8e-4c13-9383-5a12c203657e", null, "ApplicationRole", "Admin", null },
                    { "798b7f51-1d77-40b2-98c2-16a79695104d", null, "ApplicationRole", "Manager", null },
                    { "c33dd20b-67e8-4e0c-b19a-bc4b6a52ff9d", null, "ApplicationRole", "Owner", null },
                    { "da93398f-7d0c-40cf-879e-58b5b79f5067", null, "ApplicationRole", "StudentLevel_1", null },
                    { "fedc47a8-4967-4e33-a037-75161090f962", null, "ApplicationRole", "User", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d12d32af-867e-4b46-b9de-3a10322e13f1", "1fd240ef-c0d2-4df6-96e9-98e8f42725f1" });

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "903bf213-5854-46c4-a73c-e2657be47f13",
                column: "Name",
                value: "Exam on the topic (reading)");

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "f237af31-884e-4c25-a8b1-8206abebee50",
                column: "Name",
                value: "Exam on the topic (listening)");

            migrationBuilder.InsertData(
                table: "TypeTests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "7b4da4cf-52b5-4c78-9834-b56e9dbe491a", "Exam by group (listening)" },
                    { "9f8fb08c-0074-4860-8a95-6f49ab6bf5ac", "Exam by group (reading)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "190e0aea-cfed-4247-9a0f-551182cfe175");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5283e283-4d8e-4c13-9383-5a12c203657e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798b7f51-1d77-40b2-98c2-16a79695104d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c33dd20b-67e8-4e0c-b19a-bc4b6a52ff9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da93398f-7d0c-40cf-879e-58b5b79f5067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fedc47a8-4967-4e33-a037-75161090f962");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "7b4da4cf-52b5-4c78-9834-b56e9dbe491a");

            migrationBuilder.DeleteData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "9f8fb08c-0074-4860-8a95-6f49ab6bf5ac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a290569-c08d-4880-8e96-ea04e8e68edf", null, "ApplicationRole", "StudentLevel_1", null },
                    { "2cc1147b-4d82-4ba9-8390-68078f1e39c2", null, "ApplicationRole", "Manager", null },
                    { "b2e4e2a1-49fa-4d35-aa66-626ac6b55b57", null, "ApplicationRole", "User", null },
                    { "bfd082ae-6c5f-4de1-a229-595e41a8ccab", null, "ApplicationRole", "Owner", null },
                    { "f72d5c87-a99c-4a6f-b211-ba5b00492e29", null, "ApplicationRole", "Admin", null },
                    { "fa872ab8-b22e-4c29-b942-ef03d3e3d1df", null, "ApplicationRole", "MentorLevel_1", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bad4d2df-9052-4ec4-890b-abbe45b67c87", "2ae8a9f0-7fcf-42d7-a1d8-e206af10e995" });

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "903bf213-5854-46c4-a73c-e2657be47f13",
                column: "Name",
                value: "Exam (text)");

            migrationBuilder.UpdateData(
                table: "TypeTests",
                keyColumn: "Id",
                keyValue: "f237af31-884e-4c25-a8b1-8206abebee50",
                column: "Name",
                value: "Exam (listen)");
        }
    }
}
