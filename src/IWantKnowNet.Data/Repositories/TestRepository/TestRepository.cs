using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantKnowNet.Data.Models;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Repositories.Categories;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Records;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace IWantKnowNet.Data.Repositories.TestRepository;

public class TestRepository(
    ILogger<TestRepository> logger,
    IDataService dataService,
    ApplicationDbContext context,
    ICategoryRepository categoryRepository) : BaseRepository(logger, dataService), ITestRepository
{
    public async Task<StartTestViewModel?> StartTestAsync(
        string lang,
        string userId,
        StartTestViewModel startTestViewModel,
        int? countQuestions,
        CancellationToken cancellationToken)
    {
        var isTerm = 0;
#if DEBUG
        logger.LogInformation("StartTest");
        logger.LogInformation("TestId {0}", startTestViewModel.TestId);
        logger.LogInformation("TypeTestId {0}", startTestViewModel.TypeTestId);
        logger.LogInformation("CategoryId {0}", startTestViewModel.CategoryId);
        logger.LogInformation("UserId {0}", userId);
#endif
        //TODO need optimization in one connection or union both sp
        using (MySqlConnection conn = new MySqlConnection(context.Database.GetConnectionString()!))
        {
            using (MySqlCommand cmd = new MySqlCommand("StartTest", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TestId", startTestViewModel.TestId));
                cmd.Parameters.Add(new MySqlParameter("@TypeTestId", startTestViewModel.TypeTestId));
                cmd.Parameters.Add(new MySqlParameter("@UserId", userId));
                cmd.Parameters.Add(new MySqlParameter("@CategoryId", startTestViewModel.CategoryId));
                var categoryNameWithPath =
                    await categoryRepository.GetHierarchyCategoryAsString(lang, startTestViewModel.CategoryId!,
                        cancellationToken);
                cmd.Parameters.Add(new MySqlParameter("@CategoryName", categoryNameWithPath));
                cmd.Parameters.Add(new MySqlParameter("@CountQuestions", countQuestions));

                conn.Open();
                MySqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (sqlDataReader.Read())
                {
                    startTestViewModel.NextQuestionViewModel = new NextQuestionViewModel
                    {
                        QuestionViewModel = new QuestionViewModel
                        {
                            QuestionId = sqlDataReader.GetString(0),
                            CategoryId = sqlDataReader.GetString(1),
                            KeyS3 = sqlDataReader.GetString(2),
                            ExpiredSignedUrlS3 = sqlDataReader.GetDateTime(3),
                            SignedUrlS3 = sqlDataReader.GetString(4),
                            TitleEn = sqlDataReader.GetString(5),
                            TitleEs = sqlDataReader.GetString(6),
                            TitleRu = sqlDataReader.GetString(7),
                            ProofUrlEn = sqlDataReader.GetString(8),
                            ProofUrlEs = sqlDataReader.GetString(9),
                            ProofUrlRu = sqlDataReader.GetString(10),
                            CreaterId = sqlDataReader.GetString(14),
                            IsTerm = sqlDataReader.GetInt16(15)
                        }
                    };
                    isTerm = sqlDataReader.GetInt16(15);
                }
            }
        }
#if DEBUG
        logger.LogInformation("StartTest->GetAnswers");
        logger.LogInformation("TestId {0}", startTestViewModel.TestId);
        logger.LogInformation("TypeTestId {0}", startTestViewModel.TypeTestId ?? "null");
        logger.LogInformation("QuestionsId {0}",
            startTestViewModel.NextQuestionViewModel!.QuestionViewModel.QuestionId);
        logger.LogInformation("IsTerm {0}", isTerm);
        logger.LogInformation("CategoryId {0}", startTestViewModel.CategoryId);
#endif

        startTestViewModel.NextQuestionViewModel!.ListOfAnswers = new();
        if (startTestViewModel!.TypeTestId.Equals("a0165e11-bfcf-42e2-8e36-79f507097d0f") 
            || startTestViewModel.TypeTestId.Equals("e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0"))
        {
            startTestViewModel!.NextQuestionViewModel.ListOfAnswers = await GetCorrectAnswersForSpeakAsync(
                context,
                startTestViewModel!.NextQuestionViewModel.QuestionViewModel,
                cancellationToken);
        }
        else
        {
            using (MySqlConnection conn = new MySqlConnection(context.Database.GetConnectionString()!))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetAnswers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("@TestId", startTestViewModel.TestId));
                    cmd.Parameters.Add(new MySqlParameter("@TypeTestId", startTestViewModel.TypeTestId));
                    cmd.Parameters.Add(new MySqlParameter("@QuestionsId",
                        startTestViewModel.NextQuestionViewModel!.QuestionViewModel.QuestionId));
                    cmd.Parameters.Add(new MySqlParameter("@IsTerm", isTerm));
                    cmd.Parameters.Add(new MySqlParameter("@CategoryId", startTestViewModel.CategoryId));
                    cmd.Parameters.Add(new MySqlParameter("@CountAnswers", 5));
                    cmd.Parameters.Add(new MySqlParameter("@NumberQuestion", 1));

                    conn.Open();
                    MySqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                    while (sqlDataReader.Read())
                    {
                        startTestViewModel.NextQuestionViewModel!.ListOfAnswers.Add(new CorrectAnswerViewModel
                        {
                            CorrectAnswerId = sqlDataReader.GetString(0),
                            QuestionId = sqlDataReader.GetString(1),
                            TitleEn = sqlDataReader.GetString(2),
                            TitleEs = sqlDataReader.GetString(3),
                            TitleRu = sqlDataReader.GetString(4),
                            CreaterId = sqlDataReader.GetString(5),
                            IsTerm = isTerm
                        });
                    }
                }
            }
        }

        return startTestViewModel;
    }

    public async Task<NextQuestionViewModel?> GetNextQuestionsByCategoryIdAsync(
        string lang,
        string userId,
        NextQuestionViewModelRequest request,
        CancellationToken cancellationToken)
    {
        var isTerm = 0;

#if DEBUG
        logger.LogInformation("GetNextQuestionsByCategoryIdAsync: lang {0}, userId {1}", lang, userId, request);
        logger.LogInformation("QuestionId {0}", request.NextQuestionViewModel.QuestionViewModel.QuestionId);
        logger.LogInformation("TestId {0}", request.TestId);
#endif
        NextQuestionViewModel? result = null;

        if ((request.NextQuestionViewModel!.ListOfAnswers != null &&
             request.NextQuestionViewModel!.ListOfAnswers.Count > 0) ||
            (request.SpeakingResult))
        {
            await AddAnswersAsync(context, request, cancellationToken).ConfigureAwait(false);
        }

        //TODO Finished test need optimization. As example move to sp
        if (request.Finished)
        {
            await FinishedTest(lang, context, request, cancellationToken);

            return new NextQuestionViewModel()
            {
                QuestionViewModel = new QuestionViewModel() { IsTerm = 0 }
            };
        }
#if DEBUG
        logger.LogInformation("GetNextQuestionsByCategoryIdAsync->GetNextQuestionForTest");
        logger.LogInformation("TestId {0}", request.TestId);
        logger.LogInformation("CategoryId {0}", request.CategoryId);
#endif

        using (MySqlConnection conn = new MySqlConnection(context.Database.GetConnectionString()!))
        {
            using (MySqlCommand cmd = new MySqlCommand("GetNextQuestionForTest", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TestId", request.TestId));
                cmd.Parameters.Add(new MySqlParameter("@CategoryId", request.CategoryId));

                conn.Open();
                MySqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                while (sqlDataReader.Read())
                {
                    result = new()
                    {
                        QuestionViewModel = new QuestionViewModel
                        {
                            QuestionId = sqlDataReader.GetString(0),
                            CategoryId = sqlDataReader.GetString(1),
                            KeyS3 = sqlDataReader.GetString(2),
                            ExpiredSignedUrlS3 = sqlDataReader.GetDateTime(3),
                            SignedUrlS3 = sqlDataReader.GetString(4),
                            TitleEn = sqlDataReader.GetString(5),
                            TitleEs = sqlDataReader.GetString(6),
                            TitleRu = sqlDataReader.GetString(7),
                            ProofUrlEn = sqlDataReader.GetString(8),
                            ProofUrlEs = sqlDataReader.GetString(9),
                            ProofUrlRu = sqlDataReader.GetString(10),
                            CreaterId = sqlDataReader.GetString(14),
                            IsTerm = sqlDataReader.GetInt16(15)
                        }
                    };
                    isTerm = sqlDataReader.GetInt16(15);
                }
            }
        }

        if (result == null)
        {
            await FinishedTest(lang, context, request, cancellationToken);

            return new NextQuestionViewModel()
            {
                QuestionViewModel = new QuestionViewModel() { IsTerm = 0 }
            };
        }
#if DEBUG
        logger.LogInformation("GetNextQuestionsByCategoryIdAsync->GetAnswers");
        logger.LogInformation("TestId {0}", string.IsNullOrEmpty(request.TestId) ? "" : request.TestId);
        logger.LogInformation("TypeTestId {0}", string.IsNullOrEmpty(request.TypeTestId) ? "" : request.TypeTestId);
        logger.LogInformation("QuestionsId {0}", result!.QuestionViewModel.QuestionId);
        logger.LogInformation("IsTerm {0}", isTerm);
        logger.LogInformation("CategoryId {0}", result!.QuestionViewModel.CategoryId);
#endif

        result!.ListOfAnswers = new();

        if (request.TypeTestId.Equals("a0165e11-bfcf-42e2-8e36-79f507097d0f") || request.TypeTestId.Equals("e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0"))
        {
            result!.ListOfAnswers = await GetCorrectAnswersForSpeakAsync(
                context,
                result!.QuestionViewModel,
                cancellationToken);
        }
        else
        {
            result!.ListOfAnswers = await GetCorrectAnswersAsync(
                context,
                request.TestId,
                request.TypeTestId,
                result!.QuestionViewModel,
                5,
                1,
                cancellationToken);
        }

        return result;
    }

    #region Private methods

    private async Task FinishedTest(
        string lang,
        ApplicationDbContext context,
        NextQuestionViewModelRequest request,
        CancellationToken cancellationToken)
    {
        Dictionary<string, List<TestCorrectAnswer>>? testCorrectAnswerDictionary = null;
        List<AnswersList>? answerList = null;
        Dictionary<string, bool> resultDictionary = new Dictionary<string, bool>();
        Dictionary<string, List<AnswersList>>? answerDictionary = null;

        if (request.TypeTestId.Equals("a0165e11-bfcf-42e2-8e36-79f507097d0f")
            || request.TypeTestId.Equals("e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0"))
        {
            var testQuestionAndCorrectAnswerList = await (
                from testQuestions in context.TestQuestions
                join questions in context.Questions on testQuestions.QuestionsId equals questions.Id
                // join questionsAndCorrectAnswers in context.QuestionsAndCorrectAnswers
                //     on testQuestions.QuestionsId equals questionsAndCorrectAnswers.QuestionId
                // join correctAnswers in context.CorrectAnswers
                //     on questionsAndCorrectAnswers.CorrectAnswerId equals correctAnswers.Id
                where testQuestions.TestId.Equals(request.TestId)
                select new TestCorrectAnswer
                {
                    QuestionsId = testQuestions.QuestionsId,
                    CorrectAnswerId = Guid.Empty.ToString(),
                    Title = Regex.Replace(questions.TitleEs.ToLower(), @"\W+", "", RegexOptions.IgnoreCase),
                    TestId = testQuestions.TestId,
                    Id = Guid.Empty.ToString(),
                    NumberQuestion = 0
                }).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

            testCorrectAnswerDictionary = testQuestionAndCorrectAnswerList
                .GroupBy(o => o.QuestionsId).ToDictionary(g => g.Key, g => g.ToList());

            answerList = await (from answers in context.Answers
                where answers.TestId.Equals(request.TestId)
                select new AnswersList
                {
                    QuestionId = answers.QuestionId,
                    Title = Regex.Replace(answers.TextSpeaking.ToLower(), @"\W+", "", RegexOptions.IgnoreCase),
                    AnswerId = answers.CorrectAnswerId
                }).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

            answerDictionary = answerList
                .GroupBy(o => o.QuestionId).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var questionId in testCorrectAnswerDictionary.Keys)
            {
                var correctAnswerTitleList = testCorrectAnswerDictionary[questionId].Select(item => item.Title)
                    .ToList();
                var textSpeaking = answerDictionary.TryGetValue(questionId, out var value)
                    ? value.Select(item => item.Title).FirstOrDefault()
                    : "";
                if ((!string.IsNullOrEmpty(textSpeaking)) && (correctAnswerTitleList.IndexOf(textSpeaking) != -1))
                {
                    resultDictionary.Add(questionId, true);
                }
                else
                {
                    resultDictionary.Add(questionId, false);
                }
            }
        }
        else
        {
            //TODO need reimplementation to sp
            var testCorrectAnswerList = await (from testCorrectAnswers in context.TestCorrectAnswers
                where testCorrectAnswers.TestId.Equals(request.TestId)
                select new TestCorrectAnswer
                {
                    Id = testCorrectAnswers.Id,
                    TestId = testCorrectAnswers.TestId,
                    QuestionsId = testCorrectAnswers.QuestionsId,
                    NumberQuestion = testCorrectAnswers.NumberQuestion,
                    CorrectAnswerId = testCorrectAnswers.CorrectAnswerId
                }).ToListAsync(cancellationToken: cancellationToken);

            testCorrectAnswerDictionary = testCorrectAnswerList
                .GroupBy(o => o.QuestionsId).ToDictionary(g => g.Key, g => g.ToList());

            answerList = await (from answers in context.Answers
                join questions in context.Questions on answers.QuestionId equals questions.Id
                join questionsAndCorrectAnswers in context.QuestionsAndCorrectAnswers
                    on questions.Id equals questionsAndCorrectAnswers.QuestionId
                join correctAnswers in context.CorrectAnswers
                    on questionsAndCorrectAnswers.CorrectAnswerId equals correctAnswers.Id
                where answers.TestId.Equals(request.TestId)
                select new AnswersList
                {
                    QuestionId = questions.Id,
                    Title = questions.TitleEn.Trim(),
                    AnswerId = answers.CorrectAnswerId
                }).ToListAsync(cancellationToken: cancellationToken);

            answerDictionary = answerList
                .GroupBy(o => o.QuestionId).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var questionId in testCorrectAnswerDictionary.Keys)
            {
                var correctAnswers = testCorrectAnswerDictionary[questionId].Select(item => item.CorrectAnswerId)
                    .ToList();
                var factAnswers = answerDictionary.ContainsKey(questionId)
                    ? answerDictionary[questionId].Select(item => item.AnswerId).ToList()
                    : [];
                var res1 = correctAnswers.Except(factAnswers).ToList();
                var res2 = factAnswers.Except(correctAnswers).ToList();
                if ((res1.Count == 0) && (res2.Count == 0))
                {
                    resultDictionary.Add(questionId, true);
                }
                else
                {
                    resultDictionary.Add(questionId, false);
                    var item = await context.CompletedStudyQuestionsByRead
                        .Where(item => item.QuestionId == questionId)
                        .FirstOrDefaultAsync(cancellationToken);
                    if (item != null) item.QuantityCorrectAnswersOfQuestion = 0;
                }
            }
        }

        await context.TestResults.AddAsync(new TestResult()
        {
            Id = Guid.NewGuid().ToString(),
            TestId = request.TestId,
            CorrectAnswersCount = resultDictionary.Values.Where(i => i.Equals(true)).Count(),
            TestQuestionCount = resultDictionary.Count
        }, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
        await context.Tests
            .Where(item => item.Id == request.TestId)
            .ExecuteUpdateAsync(items => items
                    .SetProperty(p => p.Finished, true)
                    .SetProperty(p => p.CountQuestions, resultDictionary.Count),
                cancellationToken: cancellationToken);
    }

    private async Task AddAnswersAsync(
        ApplicationDbContext context,
        NextQuestionViewModelRequest request,
        CancellationToken cancellationToken)
    {
        foreach (var answer in request.NextQuestionViewModel!.ListOfAnswers!)
        {
            await context.Answers.AddAsync(new Answer()
            {
                Id = Guid.NewGuid().ToString(),
                CorrectAnswerId = answer.CorrectAnswerId,
                TestId = request.TestId,
                QuestionId = answer.QuestionId,
                ExpiredTime = request.NextQuestionViewModel.ExpiredTime,
                NumberQuestion = request.NumberQuestion,
                Seconds = answer.Seconds,
            }, cancellationToken);
        }

        if (request.SpeakingResult)
        {
            await context.Answers.AddAsync(new Answer()
            {
                Id = Guid.NewGuid().ToString(),
                CorrectAnswerId = Guid.Empty.ToString(),
                TestId = request.TestId,
                QuestionId = request.NextQuestionViewModel.QuestionViewModel.QuestionId,
                ExpiredTime = request.NextQuestionViewModel.ExpiredTime,
                NumberQuestion = request.NumberQuestion,
                Seconds = 0,
                TextSpeaking = request.TextSpeaking
            }, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);
    }

    #endregion
}