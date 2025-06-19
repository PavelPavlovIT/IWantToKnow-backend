using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IWantKnowNet.Data.Repositories.AnalyticRepository;

public class AnalyticRepository(
    IDataService dataService,
    ApplicationDbContext context) : IAnalyticRepository
{
    public async Task<Dictionary<string, List<TestResultViewModel>>> GetLastResultsTestByCategoryIdForUserByRead(string userId, string? categoryId, CancellationToken cancellationToken)
    {
        var listCategoryIds = await (from categories in context.Categories
                                     where categories.ParentId == categoryId
                                           && !categories.Hidden
                                     select categories.Id).ToListAsync(cancellationToken: cancellationToken);

        var listTestResult = await (from tests in context.Tests
                                    join results in context.TestResults on tests.Id equals results.TestId
                                    where tests.UserId == userId && listCategoryIds.Contains(tests.CategoryId)
                                      && (tests.TypeTestId.Equals("903bf213-5854-46c4-a73c-e2657be47f13") ||
                                          tests.TypeTestId.Equals("9f8fb08c-0074-4860-8a95-6f49ab6bf5ac"))
                                    orderby tests.Started descending
                                    select new TestResultViewModel
                                    {
                                        TestId = tests.Id,
                                        TypeTestId = tests.TypeTestId,
                                        TestResultId = results.Id,
                                        CategoryId = tests.CategoryId,
                                        CategoryName = tests.CategoryName,
                                        CorrectAnswersCount = results.CorrectAnswersCount,
                                        TestQuestionCount = tests.CountQuestions,
                                        DateStarted = tests.Started!.Value.DateTime.ToString("yyyy/MM/dd"),
                                        TimeStarted = tests.Started!.Value.DateTime.ToString("hh:mm"),
                                    }).ToListAsync(cancellationToken: cancellationToken);

        Dictionary<string, List<TestResultViewModel>> result = listTestResult.GroupBy(i => i.CategoryId).ToDictionary(g => g.Key, g => g.ToList());

        return result;
    }

    public async Task<Dictionary<string, List<TestResultViewModel>>> GetLastResultsTestByCategoryIdForUserByListen(string userId, string? categoryId, CancellationToken cancellationToken)
    {
        var listCategoryIds = await (from categories in context.Categories
                                     where categories.ParentId == categoryId
                                           && !categories.Hidden
                                     select categories.Id).ToListAsync(cancellationToken: cancellationToken);

        var listTestResult = await (from tests in context.Tests
                                    join results in context.TestResults on tests.Id equals results.TestId
                                    where tests.UserId == userId && listCategoryIds.Contains(tests.CategoryId)
                                      && (tests.TypeTestId.Equals("7b4da4cf-52b5-4c78-9834-b56e9dbe491a") ||
                                          tests.TypeTestId.Equals("f237af31-884e-4c25-a8b1-8206abebee50"))
                                    orderby tests.Started descending
                                    select new TestResultViewModel
                                    {
                                        TestId = tests.Id,
                                        TypeTestId = tests.TypeTestId,
                                        TestResultId = results.Id,
                                        CategoryId = tests.CategoryId,
                                        CategoryName = tests.CategoryName,
                                        CorrectAnswersCount = results.CorrectAnswersCount,
                                        TestQuestionCount = tests.CountQuestions,
                                        DateStarted = tests.Started!.Value.DateTime.ToString("yyyy/MM/dd"),
                                        TimeStarted = tests.Started!.Value.DateTime.ToString("hh:mm"),
                                    }).ToListAsync(cancellationToken: cancellationToken);

        Dictionary<string, List<TestResultViewModel>> result = listTestResult.GroupBy(i => i.CategoryId).ToDictionary(g => g.Key, g => g.ToList());

        return result;
    }
    
    public async Task<Dictionary<string, List<TestResultViewModel>>> GetLastResultsTestByCategoryIdForUserBySpeaking(string userId, string? categoryId, CancellationToken cancellationToken)
    {
        var listCategoryIds = await (from categories in context.Categories
                                     where categories.ParentId == categoryId
                                           && !categories.Hidden
                                     select categories.Id).ToListAsync(cancellationToken: cancellationToken);

        var listTestResult = await (from tests in context.Tests
                                    join results in context.TestResults on tests.Id equals results.TestId
                                    where tests.UserId == userId && listCategoryIds.Contains(tests.CategoryId)
                                      && (tests.TypeTestId.Equals("e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0") ||
                                          tests.TypeTestId.Equals("a0165e11-bfcf-42e2-8e36-79f507097d0f"))
                                    orderby tests.Started descending
                                    select new TestResultViewModel
                                    {
                                        TestId = tests.Id,
                                        TypeTestId = tests.TypeTestId,
                                        TestResultId = results.Id,
                                        CategoryId = tests.CategoryId,
                                        CategoryName = tests.CategoryName,
                                        CorrectAnswersCount = results.CorrectAnswersCount,
                                        TestQuestionCount = tests.CountQuestions,
                                        DateStarted = tests.Started!.Value.DateTime.ToString("yyyy/MM/dd"),
                                        TimeStarted = tests.Started!.Value.DateTime.ToString("hh:mm"),
                                    }).ToListAsync(cancellationToken: cancellationToken);

        Dictionary<string, List<TestResultViewModel>> result = listTestResult.GroupBy(i => i.CategoryId).ToDictionary(g => g.Key, g => g.ToList());

        return result;
    }
    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByReadAsync(string userId,
        CancellationToken cancellationToken)
    {
        var list = await (from tests in context.Tests
                          join results in context.TestResults on tests.Id equals results.TestId
                          where tests.UserId == userId
                                  && (tests.TypeTestId.Equals("903bf213-5854-46c4-a73c-e2657be47f13") ||
                                      tests.TypeTestId.Equals("9f8fb08c-0074-4860-8a95-6f49ab6bf5ac") )
                          orderby tests.Started descending
                          select new TestResultViewModel
                          {
                              TestId = tests.Id,
                              TypeTestId = tests.TypeTestId,
                              TestResultId = results.Id,
                              CategoryId = tests.CategoryId,
                              CategoryName = tests.CategoryName,
                              CorrectAnswersCount = results.CorrectAnswersCount,
                              TestQuestionCount = tests.CountQuestions,
                              DateStarted = tests.Started!.Value.DateTime.ToString("yyyy/MM/dd"),
                              TimeStarted = tests.Started!.Value.DateTime.ToString("hh:mm"),
                          }).ToListAsync(cancellationToken);


        var grouped = list
            .GroupBy(l => l.CategoryId)
            .Select(group => new GetAllLastTestByUserIdViewModel
            {
                CategoryId = group.Key,
                CategoryName = group.FirstOrDefault()?.CategoryName,
                Results = group.ToArray()
            }).ToList();

        return grouped;
    }

    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdByListenAsync(string userId,
        CancellationToken cancellationToken)
    {
        var list = await (from tests in context.Tests
                          join results in context.TestResults on tests.Id equals results.TestId
                          where tests.UserId == userId
                            && (tests.TypeTestId.Equals("f237af31-884e-4c25-a8b1-8206abebee50") || tests.TypeTestId.Equals("7b4da4cf-52b5-4c78-9834-b56e9dbe491a"))
                          orderby tests.Started descending
                          select new TestResultViewModel
                          {
                              TestId = tests.Id,
                              TypeTestId = tests.TypeTestId,
                              TestResultId = results.Id,
                              CategoryId = tests.CategoryId,
                              CategoryName = tests.CategoryName,
                              CorrectAnswersCount = results.CorrectAnswersCount,
                              TestQuestionCount = tests.CountQuestions,
                              DateStarted = tests.Started!.Value.DateTime.ToString("yyyy/MM/dd"),
                              TimeStarted = tests.Started!.Value.DateTime.ToString("hh:mm"),
                          }).ToListAsync(cancellationToken);


        var grouped = list
            .GroupBy(l => l.CategoryId)
            .Select(group => new GetAllLastTestByUserIdViewModel
            {
                CategoryId = group.Key,
                CategoryName = group.FirstOrDefault()?.CategoryName,
                Results = group.ToArray()
            }).ToList();

        return grouped;
    }

    public async Task<List<GetAllLastTestByUserIdViewModel>?> GetAllLastTestByUserIdBySpeakingAsync(string userId,
        CancellationToken cancellationToken)
    {
        var list = await (from tests in context.Tests
            join results in context.TestResults on tests.Id equals results.TestId
            where tests.UserId == userId
                  && (tests.TypeTestId.Equals("a0165e11-bfcf-42e2-8e36-79f507097d0f") || tests.TypeTestId.Equals("e84ee3a2-82ee-4bc7-898a-50fcbad4f3e0"))
            orderby tests.Started descending
            select new TestResultViewModel
            {
                TestId = tests.Id,
                TypeTestId = tests.TypeTestId,
                TestResultId = results.Id,
                CategoryId = tests.CategoryId,
                CategoryName = tests.CategoryName,
                CorrectAnswersCount = results.CorrectAnswersCount,
                TestQuestionCount = tests.CountQuestions,
                DateStarted = tests.Started!.Value.DateTime.ToString("yyyy/MM/dd"),
                TimeStarted = tests.Started!.Value.DateTime.ToString("hh:mm"),
            }).ToListAsync(cancellationToken);


        var grouped = list
            .GroupBy(l => l.CategoryId)
            .Select(group => new GetAllLastTestByUserIdViewModel
            {
                CategoryId = group.Key,
                CategoryName = group.FirstOrDefault()?.CategoryName,
                Results = group.ToArray()
            }).ToList();

        return grouped;
    }

    public async Task<IList<TestResultDetailsViewModel>> GetResultDetailByTestIdAsync(
        string lang,
        string testId,
        CancellationToken cancellationToken)
    {
        List<TestResultDetailsViewModel>? corrects = null;
        List<TestResultDetailsViewModel> incorrects = null;
        return null;
        //throw new NotImplementedException();
        //switch (lang)
        //{
        //    default:
        //        corrects = await
        //            (from resultDetails in context.TestResultDetails
        //                join results in context.TestResults
        //                    on resultDetails.TestResultId equals results.Id
        //                join tests in context.Tests
        //                    on results.TestId equals tests.Id
        //                join correctAnswers in context.CorrectAnswersEn
        //                    on resultDetails.CorrectAnswerId equals correctAnswers.Id
        //                join questions in context.QuestionsEn
        //                    on resultDetails.QuestionId equals questions.Id
        //             where tests.Id == testId
        //                      && resultDetails.CorrectAnswerId != null
        //                select new TestResultDetailsViewModel()
        //                {
        //                    TestResultDetailId = resultDetails.Id,
        //                    TestResultId = results.Id,
        //                    QuestionId = questions.Id,
        //                    Question = questions.Title,
        //                    CorrectAnswerId = resultDetails.CorrectAnswerId,
        //                    CorrectAnswerTitle = correctAnswers.Title,
        //                    IsCorrectAnswer = resultDetails.CorrectAnswerId != null,
        //                }).ToListAsync(cancellationToken);
        //        incorrects = await
        //            (from resultDetails in context.TestResultDetails
        //                join results in context.TestResults
        //                    on resultDetails.TestResultId equals results.Id
        //                join tests in context.Tests
        //                    on results.TestId equals tests.Id
        //             join incorrectAnswers in context.CorrectAnswersEn
        //                 on resultDetails.IncorrectAnswerId equals incorrectAnswers.Id
        //             join questions in context.QuestionsRu
        //                    on resultDetails.QuestionId equals questions.Id
        //             where tests.Id == testId
        //                      && resultDetails.CorrectAnswerId == null
        //                select new TestResultDetailsViewModel()
        //                {
        //                    TestResultDetailId = resultDetails.Id,
        //                    TestResultId = results.Id,
        //                    QuestionId = questions.Id,
        //                    Question = questions.Title,
        //                    Proof = questions.ProofUrl,
        //                    //todo need optimization
        //                    // CorrectAnswerId = context.CorrectAnswers
        //                    //     .FirstOrDefault(i => i.QuestionId.Equals(questions.QuestionId)).CorrectAnswerId ?? "???",
        //                    // CorrectAnswerTitle = context.CorrectAnswers
        //                    //     .FirstOrDefault(i => i.QuestionId.Equals(questions.QuestionId)).Title ?? "???",
        //                    IncorrectAnswerId = resultDetails.CorrectAnswerId,
        //                    IncorrectAnswerTitle = incorrectAnswers.Title,
        //                    IsCorrectAnswer = resultDetails.CorrectAnswerId != null,
        //                }).ToListAsync(cancellationToken);
        //        break;
        //}

        incorrects.AddRange(corrects);
        return incorrects;
    }
}