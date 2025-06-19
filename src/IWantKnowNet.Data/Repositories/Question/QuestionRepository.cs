using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IWantKnowNet.Data.Repositories.Question;

public class QuestionRepository(
    IDataService dataService,
    ApplicationDbContext context,
    IMapper mapper) : IQuestionRepository
{
    public async Task UpdateExpiredSignedUrlS3InQuestionAsync(string questionId, string signedUrlS3, DateTime expiredSignedUrlS3, CancellationToken cancellationToken)
    {

        MySqlParameter expiredSignedUrl = new MySqlParameter("@ExpiredSignedUrlS3", expiredSignedUrlS3);
        MySqlParameter signedUrl = new MySqlParameter("@SignedUrlS3", signedUrlS3);
        MySqlParameter id = new MySqlParameter("@QuestionId", questionId);

        dataService.ExecuteNonQuery(
            context.Database.GetConnectionString()!,
            "UpdateExpiredSignedUrlS3InQuestion",
            CommandType.StoredProcedure,
            id,
            expiredSignedUrl,
            signedUrl);

    }

    public async Task<IList<QuestionViewModel>?> GetQuestionsByCategoryIdAsync(
        string lang,
        string? categoryId,
        CancellationToken cancellationToken)
    {

        return await (from questions in context.Questions
                      join categoryAndQuestions in context.CategoryAndQuestions
                        on questions.Id equals categoryAndQuestions.QuestionId
                      orderby questions.OrderBy descending
                      where categoryAndQuestions.CategoryId == categoryId
                      select new QuestionViewModel()
                      {
                          QuestionId = questions.Id,
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
                      }).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<QuestionViewModel?>
        GetQuestionsByQuestionIdAsync(
            string lang,
            string questionId,
            CancellationToken cancellationToken)
    {
        return await (
            from questions in context.Questions
            join categoryAndQuestions in context.CategoryAndQuestions
              on questions.Id equals categoryAndQuestions.QuestionId
            orderby questions.OrderBy
            where questions.Id == questionId
            select new QuestionViewModel
            {
                QuestionId = questions.Id,
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
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task AddQuestionAsync(
        QuestionViewModel questionViewModel,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //int count = 0;

        //count = await context.QuestionsEn
        //    .Where(i => i.CategoryId == questionViewModel.CategoryId)
        //    .CountAsync(cancellationToken: cancellationToken);

        //var inserted = DateTime.Now;
        //await context.QuestionsEn.AddAsync(new QuestionEn()
        //{
        //    QuestionEnId = questionViewModel.QuestionId,
        //    Title = questionViewModel.TitleEn,
        //    CategoryId = questionViewModel.CategoryId,
        //    ProofUrl = questionViewModel.ProofUrlEn,
        //    ProofCRC = questionViewModel.ProofCRCEn,
        //    ApproverId = questionViewModel.ApproverId,
        //    CreaterId = questionViewModel.CreaterId,
        //}, cancellationToken);

        //await context.CategoriesEn
        //    .Where(item => item.CategoryEnId == questionViewModel.CategoryId)
        //    .ExecuteUpdateAsync(item =>
        //        item.SetProperty(p => p.CountQuestions, count + 1), cancellationToken);
        //count = await context.QuestionsEs
        //    .Where(i => i.CategoryId == questionViewModel.CategoryId)
        //    .CountAsync(cancellationToken: cancellationToken);
        //await context.QuestionsEs.AddAsync(new QuestionEs()
        //{
        //    QuestionEsId = questionViewModel.QuestionId,
        //    Title = questionViewModel.TitleEs,
        //    CategoryId = questionViewModel.CategoryId,
        //    ProofUrl = questionViewModel.ProofUrlEs,
        //    ProofCRC = questionViewModel.ProofCRCEs,
        //    ApproverId = questionViewModel.ApproverId,
        //    CreaterId = questionViewModel.CreaterId,
        //}, cancellationToken);
        //await context.CategoriesEs
        //    .Where(item => item.CategoryEsId == questionViewModel.CategoryId)
        //    .ExecuteUpdateAsync(item =>
        //        item.SetProperty(p => p.CountQuestions, count + 1), cancellationToken);

        //count = await context.QuestionsRu
        //    .Where(i => i.CategoryId == questionViewModel.CategoryId)
        //    .CountAsync(cancellationToken: cancellationToken);
        //await context.QuestionsRu.AddAsync(new QuestionRu()
        //{
        //    QuestionRuId = questionViewModel.QuestionId,
        //    Title = questionViewModel.TitleRu,
        //    CategoryId = questionViewModel.CategoryId,
        //    ProofUrl = questionViewModel.ProofUrlRu,
        //    ProofCRC = questionViewModel.ProofCRCRu,
        //    ApproverId = questionViewModel.ApproverId,
        //    CreaterId = questionViewModel.CreaterId,
        //}, cancellationToken);

        //await context.CategoriesRu
        //    .Where(item => item.CategoryRuId == questionViewModel.CategoryId)
        //    .ExecuteUpdateAsync(item =>
        //        item.SetProperty(p => p.CountQuestions, count + 1), cancellationToken);


        //var correctAnswersId = Guid.NewGuid().ToString();
        //if (string.IsNullOrEmpty(questionViewModel.CorrectAnswerEn) == false)
        //{
        //    await context.CorrectAnswersEn.AddAsync(new Entity.CorrectAnswerEn()
        //    {
        //        CorrectAnswerEnId = correctAnswersId,
        //        QuestionId = questionViewModel.QuestionId,
        //        Title = questionViewModel.CorrectAnswerEn,
        //        CreaterId = questionViewModel.CreaterId
        //    }, cancellationToken);
        //}

        //if (string.IsNullOrEmpty(questionViewModel.CorrectAnswerEs) == false)
        //{
        //    await context.CorrectAnswersEs.AddAsync(new Entity.CorrectAnswerEs()
        //    {
        //        CorrectAnswerEsId = correctAnswersId,
        //        QuestionId = questionViewModel.QuestionId,
        //        Title = questionViewModel.CorrectAnswerEs,
        //        CreaterId = questionViewModel.CreaterId
        //    }, cancellationToken);
        //}

        //if (string.IsNullOrEmpty(questionViewModel.CorrectAnswerRu) == false)
        //{
        //    await context.CorrectAnswersRu.AddAsync(new Entity.CorrectAnswerRu()
        //    {
        //        CorrectAnswerRuId = correctAnswersId,
        //        QuestionId = questionViewModel.QuestionId,
        //        Title = questionViewModel.CorrectAnswerRu,
        //        CreaterId = questionViewModel.CreaterId
        //    }, cancellationToken);
        //}

        //await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateQuestionAsync(
        QuestionViewModel questionViewModel,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //var updated = DateTime.Now;

        //context.Questions.Update(new Entity.Question()
        //{
        //    Id = questionViewModel.QuestionId,
        //    CategoryId = questionViewModel.CategoryId,
        //    KeyS3 = questionViewModel.KeyS3,
        //    ExpiredSignedUrlS3 = questionViewModel.ExpiredSignedUrlS3!.Value,
        //    SignedUrlS3 = questionViewModel.SignedUrlS3,
        //    TitleEn = questionViewModel.TitleEn,
        //    TitleEs = questionViewModel.TitleEs,
        //    TitleRu = questionViewModel.TitleRu,
        //    ProofUrlEn = questionViewModel.ProofUrlEn,
        //    ProofUrlEs = questionViewModel.ProofUrlEs,
        //    ProofUrlRu = questionViewModel.ProofUrlRu,
        //    ProofCRCEn = questionViewModel.ProofCRCEn,
        //    ProofCRCEs = questionViewModel.ProofCRCEs,
        //    ProofCRCRu = questionViewModel.ProofCRCRu,
        //    ApproverId = questionViewModel.ApproverId,
        //    CreaterId = questionViewModel.CreaterId,
        //});

        //await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveQuestionAsync(QuestionViewModel questionViewModel, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        //await context.CorrectAnswersEn
        //    .Where(item => item.QuestionId == questionViewModel.QuestionId)
        //    .ExecuteDeleteAsync(cancellationToken: cancellationToken);
        //await context.CorrectAnswersEs
        //    .Where(item => item.QuestionId == questionViewModel.QuestionId)
        //    .ExecuteDeleteAsync(cancellationToken: cancellationToken);
        //await context.CorrectAnswersRu
        //    .Where(item => item.QuestionId == questionViewModel.QuestionId)
        //    .ExecuteDeleteAsync(cancellationToken: cancellationToken);

        //await context.IncorrectAnswers
        //    .Where(item => item.QuestionId == questionViewModel.QuestionId)
        //    .ExecuteDeleteAsync(cancellationToken: cancellationToken);

        //var countEs = await context.QuestionsEs
        //    .Where(i => i.CategoryId == questionViewModel.CategoryId)
        //    .CountAsync(cancellationToken: cancellationToken);

        //context.QuestionsEs.Remove(mapper.Map<Entity.QuestionEs>(questionViewModel));
        //await context.CategoriesEs
        //    .Where(item => item.CategoryEsId == questionViewModel.CategoryId)
        //    .ExecuteUpdateAsync(item =>
        //        item.SetProperty(p => p.CountQuestions, countEs - 1), cancellationToken);

        //var countRu = await context.QuestionsRu
        //    .Where(i => i.CategoryId == questionViewModel.CategoryId)
        //    .CountAsync(cancellationToken: cancellationToken);

        //context.QuestionsRu.Remove(mapper.Map<Entity.QuestionRu>(questionViewModel));
        //await context.CategoriesRu
        //    .Where(item => item.CategoryRuId == questionViewModel.CategoryId)
        //    .ExecuteUpdateAsync(item =>
        //        item.SetProperty(p => p.CountQuestions, countRu - 1), cancellationToken);
        //var countEn = await context.QuestionsEn
        //    .Where(i => i.CategoryId == questionViewModel.CategoryId)
        //    .CountAsync(cancellationToken: cancellationToken);

        //context.QuestionsEn.Remove(mapper.Map<Entity.QuestionEn>(questionViewModel));
        //await context.CategoriesEn
        //    .Where(item => item.CategoryEnId == questionViewModel.CategoryId)
        //    .ExecuteUpdateAsync(item =>
        //        item.SetProperty(p => p.CountQuestions, countEn - 1), cancellationToken);

        //await context.SaveChangesAsync(cancellationToken);
        //await transaction.CommitAsync(cancellationToken);
    }
}