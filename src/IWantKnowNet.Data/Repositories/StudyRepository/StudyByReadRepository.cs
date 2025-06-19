using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantKnowNet.Data.Models;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Repositories.TestRepository;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Records;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using static IWantKnowNet.Data.Repositories.TestRepository.TestRepository;

namespace IWantKnowNet.Data.Repositories.StudyRepository;

public class StudyByReadRepository(
    IConfiguration configuration,
    ILogger<StudyByReadRepository> logger,
    IDataService dataService,
    ApplicationDbContext context) : BaseRepository(logger, dataService), IStudyByReadRepository
{
    private async Task<StartTestViewModel?> GetNextQuestionForStudyAsync(ApplicationDbContext context, string userId, string categoryId, CancellationToken cancellationToken)
    {
        Random rnd = new Random();

        List<NextQuestionRecord>? firstQuestionsRecord = await (
            from completedStudyQuestions in context.CompletedStudyQuestionsByRead
            join questions in context.Questions on completedStudyQuestions.QuestionId equals questions.Id
            join categoryAndQuestions in context.CategoryAndQuestions
                on questions.Id equals categoryAndQuestions.QuestionId
            let _userId = completedStudyQuestions.UserId
            let _quantity = completedStudyQuestions.QuantityCorrectAnswersOfQuestion
            let _quantityCorrectAnswersOfQuestion = int.Parse(configuration["QuantityCorrectAnswersOfQuestion"]!)
            where categoryAndQuestions.CategoryId == categoryId && _quantity < _quantityCorrectAnswersOfQuestion
            && _userId.Equals(userId)
            orderby completedStudyQuestions.QuantityCorrectAnswersOfQuestion
            select new NextQuestionRecord
                (
                    new NextQuestionViewModel
                    {
                        QuestionViewModel = new QuestionViewModel
                        {
                            QuestionId = completedStudyQuestions.QuestionId,
                            IsTerm = questions.IsTerm,
                            CategoryId = categoryAndQuestions.CategoryId,
                            KeyS3 = questions.KeyS3,
                            ExpiredSignedUrlS3 = questions.ExpiredSignedUrlS3,
                            SignedUrlS3 = questions.SignedUrlS3,
                            TitleEn = questions.TitleEn,
                            TitleEs = questions.TitleEs,
                            TitleRu = questions.TitleRu,
                            ProofUrlEn = questions.ProofUrlEn,
                            ProofCRCEn = questions.ProofCRCEn,
                            ProofUrlEs = questions.ProofUrlEs,
                            ProofCRCEs = questions.ProofCRCEs,
                            ProofUrlRu = questions.ProofUrlRu,
                            ProofCRCRu = questions.ProofCRCRu,
                            CreaterId = questions.CreaterId,
                            ApproverId = questions.ApproverId
                        },
                        Started = null,
                        ExpiredTime = false,
                        ListOfAnswers = null
                    },
                    rnd.Next(1, 1000)
                ))
            .ToListAsync(cancellationToken);

        if (firstQuestionsRecord.Count.Equals(0)) return new StartTestViewModel()
        {
            TestId = "completed",
            CountQuestion = -1,
            TypeTestId = string.Empty,
            NextQuestionViewModel = new NextQuestionViewModel
            {
                QuestionViewModel = new() { QuestionId = "completed", IsTerm = 0 }
            }
        }; ;

        var nextQuestionViewModel = firstQuestionsRecord!.OrderBy(i => i.rand).FirstOrDefault()!.QuestionViewModel;

        nextQuestionViewModel.ListOfAnswers = await GetCorrectAnswersAsync(
            context,
            null,
            null,
            nextQuestionViewModel.QuestionViewModel,
            5,
            1,
            cancellationToken);

        return new StartTestViewModel()
        {
            TestId = "study",
            CountQuestion = -1,
            TypeTestId = string.Empty,
            NextQuestionViewModel = nextQuestionViewModel
        };
    }
    public async Task<StartTestViewModel?> StartStudyAsync(string lang, string userId, string categoryId, CancellationToken cancellationToken)
    {
        //TODO !!! need check userId everywhere

        var completedStudyQuestionList = await (
                from questions in context.Questions
                join categoryAndQuestions in context.CategoryAndQuestions
                    on questions.Id equals categoryAndQuestions.QuestionId
                join completedStudyQuestions in context.CompletedStudyQuestionsByRead
                    on questions.Id equals completedStudyQuestions.QuestionId
                let _userId = completedStudyQuestions.UserId
                orderby questions.OrderBy descending
                where categoryAndQuestions.CategoryId == categoryId && _userId.Equals(userId)
                select questions)
                .AsNoTracking()
            .ToListAsync(cancellationToken);

        if (completedStudyQuestionList.Count == 0)
        {

            var listQuestion = await (
                    from questions in context.Questions
                    join categoryAndQuestions in context.CategoryAndQuestions
                        on questions.Id equals categoryAndQuestions.QuestionId
                    orderby questions.OrderBy descending
                    where categoryAndQuestions.CategoryId == categoryId
                    select questions)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

            listQuestion.ForEach(async void (i) =>
                await context.CompletedStudyQuestionsByRead.AddAsync(
                    new CompletedStudyQuestionByRead()
                    {
                        Id = Guid.NewGuid().ToString(),
                        QuestionId = i.Id,
                        QuantityCorrectAnswersOfQuestion = 0,
                        UserId = userId
                    }, cancellationToken));

            await context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var listQuestion = await (
                from questions in context.Questions
                join categoryAndQuestions in context.CategoryAndQuestions
                    on questions.Id equals categoryAndQuestions.QuestionId
                orderby questions.OrderBy descending
                where categoryAndQuestions.CategoryId == categoryId
                select questions)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (completedStudyQuestionList.Count < listQuestion.Count)
            {
                foreach(var item in completedStudyQuestionList)
                {
                    var question = listQuestion.FirstOrDefault(i => i.Id.Equals(item.Id));
                    listQuestion.Remove(question);
                }

                listQuestion.ForEach(async void (i) =>
                    await context.CompletedStudyQuestionsByRead.AddAsync(
                        new CompletedStudyQuestionByRead()
                        {
                            Id = Guid.NewGuid().ToString(),
                            QuestionId = i.Id,
                            QuantityCorrectAnswersOfQuestion = 0,
                            UserId = userId
                        }, cancellationToken));

                await context.SaveChangesAsync(cancellationToken);

            }
        }

        return await GetNextQuestionForStudyAsync(context, userId, categoryId, cancellationToken);
    }
    public async Task<bool> CheckAnswerStudyAsync(
        string lang,
        string userId,
        NextQuestionViewModelRequest request,
        CancellationToken cancellationToken)
    {
        var result = false;

        Dictionary<string, CorrectAnswerViewModel> correctAnswerDict = await (
            from correctAnswers in context.CorrectAnswers
            join questionsAndCorrectAnswers in context.QuestionsAndCorrectAnswers
                 on correctAnswers.Id equals questionsAndCorrectAnswers.CorrectAnswerId
            where questionsAndCorrectAnswers.QuestionId.Equals(request.NextQuestionViewModel!.QuestionViewModel.QuestionId)
            select new CorrectAnswerViewModel
            {
                CorrectAnswerId = correctAnswers.Id,
                QuestionId = questionsAndCorrectAnswers.QuestionId,
                TitleEn = correctAnswers.TitleEn,
                TitleEs = correctAnswers.TitleEs,
                TitleRu = correctAnswers.TitleRu,
                CreaterId = correctAnswers.CreaterId,
                ApproverId = correctAnswers.ApproverId,
                IsTerm = correctAnswers.IsTerm
            }).ToDictionaryAsync(i => i.CorrectAnswerId, cancellationToken: cancellationToken);

        if ((correctAnswerDict.Count == 0) && (request.NextQuestionViewModel!.ListOfAnswers!.Count == 0))
        {
            return true;
        }

        List<string> listCorrectIds = new();
        List<string> listIds = request.NextQuestionViewModel!.ListOfAnswers!.Select(i=>i.CorrectAnswerId).ToList();

        foreach (var item in request.NextQuestionViewModel!.InputOfAnswers!)
        {
            if (correctAnswerDict.ContainsKey(item.CorrectAnswerId))
            {
                listCorrectIds.Add(item.CorrectAnswerId);
            }
        }

        var res1 = listCorrectIds.Except(listIds).ToList();
        var res2 = listIds.Except(listCorrectIds).ToList();
        if ((res1.Count == 0) && (res2.Count == 0))
        {
            result = true;
        }

        if (result)
        {
            var item = await context.CompletedStudyQuestionsByRead
                .Where(item => item.QuestionId == request.NextQuestionViewModel!.QuestionViewModel.QuestionId)
                .FirstOrDefaultAsync(cancellationToken);

            item!.QuantityCorrectAnswersOfQuestion++;
        }
        else
        {
            var item = await context.CompletedStudyQuestionsByRead
                .Where(item => item.QuestionId == request.NextQuestionViewModel!.QuestionViewModel.QuestionId)
                .FirstOrDefaultAsync(cancellationToken);

            item!.QuantityCorrectAnswersOfQuestion = 0;
        }

        await context.SaveChangesAsync(cancellationToken);
        return result;
    }
    public async Task<NextQuestionViewModel?> GetNextQuestionsForStudyAsync(string lang, string userId, NextQuestionViewModelRequest request, CancellationToken cancellationToken)
    {

        return (await GetNextQuestionForStudyAsync(context, userId, request.CategoryId, cancellationToken))!.NextQuestionViewModel;
    }

}