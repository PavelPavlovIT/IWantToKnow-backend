using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWantKnowNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Language = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssignTests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MentorId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MemberId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    Canceled = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignTests", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoryAndQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAndQuestions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedStudyQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuantityCorrectAnswersOfQuestion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedStudyQuestions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MemberTeams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MentorId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MemeberId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Nickname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTeams", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    TxId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Success = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuestionsAndCorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsAndCorrectAnswers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuestionsAndIncorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IncorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsAndIncorrectAnswers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudyQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionsId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    Started = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    Finished = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyQuestions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionsId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    NumberQuestion = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IsCorrect = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestCorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionsId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    NumberQuestion = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCorrectAnswers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestIncorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionsId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IncorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestIncorrectAnswers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionsId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    Started = table.Column<DateTimeOffset>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeTests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTests", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ParentId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    NameEn = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    NameEs = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    NameRu = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    DescriptionEn = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    DescriptionEs = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    DescriptionRu = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    CreaterId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    CountQuestions = table.Column<int>(type: "int", nullable: false),
                    Hidden = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TitleEn = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    TitleEs = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    TitleRu = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    CreaterId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ApproverId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectAnswers_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncorrectAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TitleEn = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    TitleEs = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    TitleRu = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    CreaterId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ApproverId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncorrectAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncorrectAnswers_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TitleEn = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    TitleEs = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    TitleRu = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    ProofUrlEn = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    ProofUrlEs = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    ProofUrlRu = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    KeyS3 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ExpiredSignedUrlS3 = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SignedUrlS3 = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    CreaterId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ApproverId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    ProofCRCEn = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ProofCRCEs = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ProofCRCRu = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_CreaterId",
                        column: x => x.CreaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CategoryName = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    Started = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    CountQuestions = table.Column<int>(type: "int", nullable: false),
                    Finished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TypeTestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_TypeTests_TypeTestId",
                        column: x => x.TypeTestId,
                        principalTable: "TypeTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Seconds = table.Column<int>(type: "int", nullable: true),
                    NumberQuestion = table.Column<int>(type: "int", nullable: false),
                    ExpiredTime = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_CorrectAnswers_CorrectAnswerId",
                        column: x => x.CorrectAnswerId,
                        principalTable: "CorrectAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CorrectAnswersCount = table.Column<int>(type: "int", nullable: false),
                    TestQuestionCount = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResult_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestResultDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionTitle = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    CorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    IncorrectAnswerId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    TestResultId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    QuestionId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResultDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResultDetails_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestResultDetails_TestResult_TestResultId",
                        column: x => x.TestResultId,
                        principalTable: "TestResult",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48b9de24-e112-46b0-9633-b31da463461b", null, "ApplicationRole", "Owner", null },
                    { "5630f77e-7312-4bb0-a4da-dc009eae83c7", null, "ApplicationRole", "Admin", null },
                    { "7a4e86e1-9506-4a4c-8c54-fdd079a36e62", null, "ApplicationRole", "StudentLevel_1", null },
                    { "a823a3e6-090f-4126-9d1f-3decac52e805", null, "ApplicationRole", "Manager", null },
                    { "b877f246-e349-4825-a3e8-320271f790ac", null, "ApplicationRole", "User", null },
                    { "e699e1a7-a73b-4097-b2eb-3d8f33e35f3e", null, "ApplicationRole", "MentorLevel_1", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Language", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", 0, "11d6ad14-f9b6-41fe-bc55-ede0f886f050", "default", false, "en", false, null, null, null, null, null, false, "da759796-b02a-4099-92fd-6f587bfdca89", false, "default" });

            migrationBuilder.InsertData(
                table: "TypeTests",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "25d763ee-7229-467a-84cc-4dacffe1a8ff", "Exam (speak)" },
                    { "2cf853d6-c33a-402f-9e18-5a4e904e5fad", "WorkOnMistakes" },
                    { "33ec0a13-cda5-4286-86c7-73eae18dd762", "Training" },
                    { "903bf213-5854-46c4-a73c-e2657be47f13", "Exam (text)" },
                    { "ac6a1d9c-6eff-40a0-a0d3-02784b4cc804", "AssignTest" },
                    { "f237af31-884e-4c25-a8b1-8206abebee50", "Exam (listen)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CorrectAnswerId",
                table: "Answers",
                column: "CorrectAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TestId",
                table: "Answers",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreaterId",
                table: "Categories",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAndQuestions_QuestionId_CategoryId",
                table: "CategoryAndQuestions",
                columns: new[] { "QuestionId", "CategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectAnswers_CreaterId",
                table: "CorrectAnswers",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectAnswers_TitleEn",
                table: "CorrectAnswers",
                column: "TitleEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectAnswers_TitleEs",
                table: "CorrectAnswers",
                column: "TitleEs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectAnswers_TitleRu",
                table: "CorrectAnswers",
                column: "TitleRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncorrectAnswers_CreaterId",
                table: "IncorrectAnswers",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_IncorrectAnswers_TitleEn",
                table: "IncorrectAnswers",
                column: "TitleEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncorrectAnswers_TitleEs",
                table: "IncorrectAnswers",
                column: "TitleEs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncorrectAnswers_TitleRu",
                table: "IncorrectAnswers",
                column: "TitleRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreaterId",
                table: "Questions",
                column: "CreaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TitleEn",
                table: "Questions",
                column: "TitleEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TitleEs",
                table: "Questions",
                column: "TitleEs",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TitleRu",
                table: "Questions",
                column: "TitleRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAndCorrectAnswers_QuestionId_CorrectAnswerId",
                table: "QuestionsAndCorrectAnswers",
                columns: new[] { "QuestionId", "CorrectAnswerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAndIncorrectAnswers_QuestionId_IncorrectAnswerId",
                table: "QuestionsAndIncorrectAnswers",
                columns: new[] { "QuestionId", "IncorrectAnswerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_TestId",
                table: "TestResult",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResultDetails_QuestionId",
                table: "TestResultDetails",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResultDetails_TestResultId",
                table: "TestResultDetails",
                column: "TestResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CategoryId",
                table: "Tests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TypeTestId",
                table: "Tests",
                column: "TypeTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssignTests");

            migrationBuilder.DropTable(
                name: "CategoryAndQuestions");

            migrationBuilder.DropTable(
                name: "CompletedStudyQuestions");

            migrationBuilder.DropTable(
                name: "IncorrectAnswers");

            migrationBuilder.DropTable(
                name: "MemberTeams");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "QuestionsAndCorrectAnswers");

            migrationBuilder.DropTable(
                name: "QuestionsAndIncorrectAnswers");

            migrationBuilder.DropTable(
                name: "StudyQuestions");

            migrationBuilder.DropTable(
                name: "TestAnswers");

            migrationBuilder.DropTable(
                name: "TestCorrectAnswers");

            migrationBuilder.DropTable(
                name: "TestIncorrectAnswers");

            migrationBuilder.DropTable(
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "TestResultDetails");

            migrationBuilder.DropTable(
                name: "CorrectAnswers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TypeTests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
