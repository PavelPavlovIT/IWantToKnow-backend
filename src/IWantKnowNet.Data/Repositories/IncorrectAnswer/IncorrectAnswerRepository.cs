using AutoMapper;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Repositories.Base;
using IWantKnowNet.Data.Services;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IWantKnowNet.Data.Repositories.IncorrectAnswer;

public class IncorrectAnswerRepository(
    IDataService dataService) : IIncorrectAnswerRepository
{
    public async Task<IList<IncorrectAnswerViewModel>?>
        GetIncorrectAnswersByQuestionIdAsync(string questionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //return await context.IncorrectAnswers
        //    .Where(q => q.QuestionId == questionId)
        //    .Select(item => new IncorrectAnswerViewModel
        //    (
        //        item.IncorrectAnswerId,
        //        item.QuestionId,
        //        item.Title,
        //        item.CreaterId,
        //        item.ApproverId,
        //        item.Created,
        //        item.Changed
        //    ))
        //    .ToListAsync(cancellationToken);
        //return null;
    }

    public async Task<IList<IncorrectAnswerViewModel>?>
        GetIncorrectAnswersByCategoryIdAsync(string categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //
        // var categories = context.Categories;
        // var questions = context.Questions;
        //
        // var query = categories
        //     .Where(item => item.CategoryId == categoryId)
        //     .Join(
        //         questions,
        //         category => category.CategoryId,
        //         question => question.CategoryId,
        //         (category, question) => new
        //         {
        //             questionId = question.QuestionId
        //         })
        //     .GroupBy(record => record.questionId);
        // var list = await query.ToListAsync(cancellationToken: cancellationToken);
        //return null;
    }

    public async Task AddIncorrectAnswerAsync(IncorrectAnswerViewModel incorrectAnswerViewModel,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //await context.IncorrectAnswers.AddAsync(new Entity.IncorrectAnswerEn
        //{
        //    IncorrectAnswerId = incorrectAnswerViewModel.IncorrectAnswerId,
        //    QuestionId = incorrectAnswerViewModel.QuestionId,
        //    Title = incorrectAnswerViewModel.Title,
        //    CreaterId = incorrectAnswerViewModel.CreaterId,
        //    ApproverId = incorrectAnswerViewModel.ApproverId,
        //    Created = incorrectAnswerViewModel.Created,
        //    Changed = incorrectAnswerViewModel.Changed,
        //}, cancellationToken);

        //await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateIncorrectAnswerAsync(IncorrectAnswerViewModel incorrectAnswerViewModel,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //context.IncorrectAnswers.Update(new Entity.IncorrectAnswerEn
        //{
        //    IncorrectAnswerId = incorrectAnswerViewModel.IncorrectAnswerId,
        //    QuestionId = incorrectAnswerViewModel.QuestionId,
        //    Title = incorrectAnswerViewModel.Title,
        //    CreaterId = incorrectAnswerViewModel.CreaterId,
        //    ApproverId = incorrectAnswerViewModel.ApproverId,
        //    Created = incorrectAnswerViewModel.Created,
        //    Changed = incorrectAnswerViewModel.Changed,
        //});

        //await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveIncorrectAnswerAsync(IncorrectAnswerViewModel incorrectAnswerViewModel,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //var incorrectAnswer =
        //    await context.IncorrectAnswersEn.FindAsync(incorrectAnswerViewModel.IncorrectAnswerId, cancellationToken);
        //context.IncorrectAnswersEn.Remove(incorrectAnswer!);

        //var incorrectAnswer =
        //    await context.IncorrectAnswersEn.FindAsync(incorrectAnswerViewModel.IncorrectAnswerId, cancellationToken);
        //context.IncorrectAnswersEn.Remove(incorrectAnswer!);

        //var incorrectAnswer =
        //    await context.IncorrectAnswersEn.FindAsync(incorrectAnswerViewModel.IncorrectAnswerId, cancellationToken);
        //context.IncorrectAnswersEn.Remove(incorrectAnswer!);
        //await context.SaveChangesAsync(cancellationToken);
    }
}