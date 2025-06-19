using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class added_TextSpeaking_to_answer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "TextSpeaking",
                table: "Answers",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "TextSpeaking",
                table: "Answers");

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
    }
}
