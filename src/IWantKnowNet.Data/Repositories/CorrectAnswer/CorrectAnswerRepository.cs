using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IWantKnowNet.Data.Repositories.CorrectAnswer;

public class CorrectAnswerRepository(
    IDataService dataService,
    ApplicationDbContext context) : ICorrectAnswerRepository
{
    public async Task<IList<CorrectAnswerViewModel>?>
        GetCorrectAnswersByQuestionIdAsync(
            string lang, string questionId, CancellationToken cancellationToken)
    {
        List<CorrectAnswerViewModel>? results = null;

        return await (from correctAnswers in context.CorrectAnswers
                      join questionsAndCorrectAnswers in context.QuestionsAndCorrectAnswers
                           on correctAnswers.Id equals questionsAndCorrectAnswers.CorrectAnswerId
                      orderby correctAnswers.OrderBy
                      where questionsAndCorrectAnswers.QuestionId == questionId
                      select new CorrectAnswerViewModel
                      {
                          CorrectAnswerId = correctAnswers.Id,
                          QuestionId = questionsAndCorrectAnswers.QuestionId,
                          TitleEn = correctAnswers.TitleEn,
                          TitleRu = correctAnswers.TitleEs,
                          TitleEs = correctAnswers.TitleRu,
                          ApproverId = correctAnswers.ApproverId,
                          IsTerm = correctAnswers.IsTerm
                      }
            ).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IList<CorrectAnswerViewModel>?> GetCorrectAnswersByCategoryIdAsync(
        string lang, string categoryId, CancellationToken cancellationToken)
    {
        var result = await (
                from categories in context.Categories
                join categoryAndQuestions in context.CategoryAndQuestions
                    on categories.Id equals categoryAndQuestions.CategoryId
                join questions in context.Questions on categoryAndQuestions.QuestionId equals questions.Id
                    into questionsGroup
                from questionResult in questionsGroup.DefaultIfEmpty()
                join questionsAndCorrectAnswers in context.QuestionsAndCorrectAnswers
                     on questionResult.Id equals questionsAndCorrectAnswers.QuestionId

                join correctAnswers in context.CorrectAnswers
                    on questionsAndCorrectAnswers.CorrectAnswerId equals correctAnswers.Id
                    into correctAnswersGroup
                from correctAnswersResult in correctAnswersGroup.DefaultIfEmpty()
                where categories.Id == categoryId
                select new CorrectAnswerViewModel
                {
                    CorrectAnswerId = correctAnswersResult.Id,
                    QuestionId = questionsAndCorrectAnswers.QuestionId,
                    TitleEn = correctAnswersResult.TitleEn,
                    TitleEs = correctAnswersResult.TitleEs,
                    TitleRu = correctAnswersResult.TitleRu,
                    ApproverId = correctAnswersResult.ApproverId,
                    IsTerm = correctAnswersResult.IsTerm
                })
            .ToListAsync(cancellationToken: cancellationToken);

        return result;
    }

    public async Task AddCorrectAnswerAsync(
        CorrectAnswerViewModel correctAnswerViewModel,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        //await context.CorrectAnswersEn.AddAsync(
        //    new CorrectAnswerEn()
        //    {
        //        Title = correctAnswerViewModel.TitleEn,
        //        QuestionId = correctAnswerViewModel.QuestionId,
        //        ApproverId = correctAnswerViewModel.ApproverId,
        //        CorrectAnswerEnId = correctAnswerViewModel.CorrectAnswerId,
        //        CreaterId = correctAnswerViewModel.CreaterId,
        //    }, cancellationToken);

        //await context.CorrectAnswersEs.AddAsync(
        //    new CorrectAnswerEs()
        //    {
        //        Title = correctAnswerViewModel.TitleEs,
        //        QuestionId = correctAnswerViewModel.QuestionId,
        //        ApproverId = correctAnswerViewModel.ApproverId,
        //        CorrectAnswerEsId = correctAnswerViewModel.CorrectAnswerId,
        //        CreaterId = correctAnswerViewModel.CreaterId,
        //    }, cancellationToken);
        //await context.CorrectAnswersRu.AddAsync(
        //    new CorrectAnswerRu()
        //    {
        //        Title = correctAnswerViewModel.TitleRu,
        //        QuestionId = correctAnswerViewModel.QuestionId,
        //        ApproverId = correctAnswerViewModel.ApproverId,
        //        CorrectAnswerRuId = correctAnswerViewModel.CorrectAnswerId,
        //        CreaterId = correctAnswerViewModel.CreaterId!,
        //    }, cancellationToken);

        //await context.SaveChangesAsync(cancellationToken);
        //await transaction.CommitAsync(cancellationToken);
    }

    public async Task UpdateCorrectAnswerAsync(CorrectAnswerViewModel correctAnswerViewModel,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //context.CorrectAnswersEn.Update(new CorrectAnswerEn()
        //{
        //    Title = correctAnswerViewModel.TitleEn,
        //    QuestionId = correctAnswerViewModel.QuestionId,
        //    ApproverId = correctAnswerViewModel.ApproverId,
        //    CorrectAnswerEnId = correctAnswerViewModel.CorrectAnswerId,
        //    CreaterId = correctAnswerViewModel.CreaterId,
        //});
        //context.CorrectAnswersEs.Update(new CorrectAnswerEs()
        //{
        //    Title = correctAnswerViewModel.TitleEs,
        //    QuestionId = correctAnswerViewModel.QuestionId,
        //    ApproverId = correctAnswerViewModel.ApproverId,
        //    CorrectAnswerEsId = correctAnswerViewModel.CorrectAnswerId,
        //    CreaterId = correctAnswerViewModel.CreaterId,
        //});
        //context.CorrectAnswersRu.Update(new CorrectAnswerRu()
        //{
        //    Title = correctAnswerViewModel.TitleRu,
        //    QuestionId = correctAnswerViewModel.QuestionId,
        //    ApproverId = correctAnswerViewModel.ApproverId,
        //    CorrectAnswerRuId = correctAnswerViewModel.CorrectAnswerId,
        //    CreaterId = correctAnswerViewModel.CreaterId,
        //});

        //await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveCorrectAnswerAsync(
        CorrectAnswerViewModel correctAnswerViewModel,
        CancellationToken cancellationToken)
    {

        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var correctAnswer =
            await context.CorrectAnswers.FindAsync(correctAnswerViewModel.CorrectAnswerId, cancellationToken);
        context.CorrectAnswers.Remove(correctAnswer!);

        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}