using IWantKnowNet.Data.Extensions;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_sp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddQuestionAndOneCorrectAnswer();
            migrationBuilder.UpdateExpiredSignedUrlS3InQuestion();
            migrationBuilder.StartTest();
            migrationBuilder.GetAnswers();
            migrationBuilder.GetNextQuestionForTest();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
