using IWantKnowNet.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace IWantKnowNet.Data.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration) : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CategoryAndQuestion> CategoryAndQuestions { get; set; }

        public DbSet<TypeTest> TypeTests { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }

        public DbSet<IncorrectAnswer> IncorrectAnswers { get; set; }
        public DbSet<QuestionAndCorrectAnswer> QuestionsAndCorrectAnswers { get; set; }
        public DbSet<QuestionAndIncorrectAnswer> QuestionsAndIncorrectAnswers { get; set; }

        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<CompletedStudyQuestionBySpeakEasyLevel> CompletedStudyQuestionsBySpeakEasyLevel { get; set; }
        public DbSet<CompletedStudyQuestionBySpeakMediumLevel> CompletedStudyQuestionsBySpeakMediumLevel { get; set; }
        public DbSet<CompletedStudyQuestionBySpeakDifficultLevel> CompletedStudyQuestionsBySpeakDifficultLevel { get; set; }
        public DbSet<CompletedStudyQuestionByRead> CompletedStudyQuestionsByRead { get; set; }
        public DbSet<CompletedStudyQuestionByListen> CompletedStudyQuestionsByListen { get; set; }
        
        public DbSet<TestAnswer> TestAnswers { get; set; }
        public DbSet<TestCorrectAnswer> TestCorrectAnswers { get; set; }
        public DbSet<TestIncorrectAnswer> TestIncorrectAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<TestResult> ResultsTests { get; set; }
        public DbSet<TestResultDetail> TestResultDetails { get; set; }
        public DbSet<StudyQuestion> StudyQuestions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MemberTeam> MemberTeams { get; set; }
        public DbSet<AssignTest> AssignTests { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser {
                    Id = Guid.Empty.ToString(),
                    UserName = "default",
                    Language="en",
                    Email= "default"
                }
            );

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Name = "Owner" },
                new ApplicationRole { Name = "User" },
                new ApplicationRole { Name = "Admin" },
                new ApplicationRole { Name = "Manager" },
                new ApplicationRole { Name = "StudentLevel_1" },
                new ApplicationRole { Name = "MentorLevel_1" }
            );

            builder.Entity<TypeTest>().HasData(
                new TypeTest
                {

                    Name = "Exam (listening)",
                    Id = "7b4da4cf-52b5-4c78-9834-b56e9dbe491a",
                },
                new TypeTest
                {
                    Name = "Exam (reading)",
                    Id = "9f8fb08c-0074-4860-8a95-6f49ab6bf5ac",
                },
                new TypeTest
                {
                    Name = "Exam (speaking)",
                    Id = "e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0",
                },
                new TypeTest
                {
                    Name = "Test (reading)",
                    Id = "903bf213-5854-46c4-a73c-e2657be47f13",
                },
                new TypeTest
                {
                    Name = "Test (listening)",
                    Id = "f237af31-884e-4c25-a8b1-8206abebee50",
                },
                new TypeTest
                {
                    Name = "Test (speaking)",
                    Id = "a0165e11-bfcf-42e2-8e36-79f507097d0f",
                },
                new TypeTest
                {
                    Name = "Study (reading)",
                    Id = "dbf39bef-b195-48c8-b328-d1087e085e18",
                },
                new TypeTest
                {
                    Name = "Study (listening)",
                    Id = "2c4286c2-a0f5-4a72-861c-12829546981b",
                },
                new TypeTest
                {
                    Name = "Study (speak on easy level)",
                    Id = "80907d2b-8387-4d4d-b7d6-1bc7d617d1bb",
                },
                new TypeTest
                {
                    Name = "Study (speak on medium level)",
                    Id = "1928f7d7-225f-4c32-b3f8-4786dc3dffee",
                },
                new TypeTest
                {
                    Name = "Study (speak on difficult level)",
                    Id = "930c9e4a-60cc-462a-9b4a-0f2e6b263932",
                }
                );
            
            builder.Entity<Category>()
                .Property(b => b.Reverse)
                .HasDefaultValue(false);
            
            builder.Entity<CompletedStudyQuestionByRead>()
                .Property(b => b.QuantityCorrectAnswersOfQuestion)
                .HasDefaultValue(0);

            builder.Entity<CompletedStudyQuestionByListen>()
                .Property(b => b.QuantityCorrectAnswersOfQuestion)
                .HasDefaultValue(0);

            builder.Entity<Test>().Property(m => m.Started).IsRequired(false);


            builder.Entity<Category>()
                .Property(b => b.OrderBy)
                .HasDefaultValue(100);

            builder.Entity<Test>()
                .HasMany(e => e.Answers)
                .WithOne(e => e.Test)
                .HasForeignKey(e => e.TestId)
                .HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TestResult>()
                .HasMany(e => e.TestResultDetails)
                .WithOne(e => e.TestResult)
                .HasForeignKey(e => e.TestResultId)
                .HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.Questions)
                .WithOne(e => e.Creater)
                .HasForeignKey(e => e.CreaterId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.CorrectAnswers)
                .WithOne(e => e.Creater)
                .HasForeignKey(e => e.CreaterId)
                .HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationUser>()
                .HasMany(e => e.IncorrectAnswers)
                .WithOne(e => e.Creater)
                .HasForeignKey(e => e.CreaterId)
                .HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Question>()
                .Property(b => b.OrderBy)
                .HasDefaultValue(100);

            builder.Entity<CorrectAnswer>()
                .Property(b => b.OrderBy)
                .HasDefaultValue(100);

            builder.Entity<IncorrectAnswer>()
                .Property(b => b.OrderBy)
                .HasDefaultValue(100);

        }
    }
}