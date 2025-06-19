using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Records;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static IWantKnowNet.Data.Repositories.TestRepository.TestRepository;
using System.Runtime.InteropServices;
using IWantKnowNet.Data.Services;
using MySql.Data.MySqlClient;
using System.Data;
using IWantKnowNet.Data.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities.Collections;
using Microsoft.Extensions.Logging;

namespace IWantKnowNet.Data.Repositories.Base;

public class BaseRepository(
    ILogger<BaseRepository> logger,
    IDataService dataService) : IBaseRepository
{
    public async Task<List<CorrectAnswerViewModel>> GetCorrectAnswersAsync(
        ApplicationDbContext context,
        string testId,
        string typeTestId,
        QuestionViewModel questionViewModel,
        int countAnswers,
        int numberQuestion,
        CancellationToken cancellationToken)
    {
#if DEBUG
        logger.LogInformation("StartTest->GetAnswers");
        logger.LogInformation("TestId {0}", testId);
        logger.LogInformation("TypeTestId {0}", typeTestId);
        logger.LogInformation("QuestionsId {0}", questionViewModel.QuestionId);
        logger.LogInformation("IsTerm {0}", questionViewModel.IsTerm);
        logger.LogInformation("CategoryId {0}", questionViewModel.CategoryId);
#endif

        List<CorrectAnswerViewModelRecord> answers = new List<CorrectAnswerViewModelRecord>();

        using (MySqlConnection conn = new MySqlConnection(context.Database.GetConnectionString()!))
        {
            using (MySqlCommand cmd = new MySqlCommand("GetAnswers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("@TestId", testId));
                cmd.Parameters.Add(new MySqlParameter("@TypeTestId", typeTestId));
                cmd.Parameters.Add(new MySqlParameter("@QuestionsId", questionViewModel.QuestionId));
                cmd.Parameters.Add(new MySqlParameter("@IsTerm", questionViewModel.IsTerm));
                cmd.Parameters.Add(new MySqlParameter("@CategoryId", questionViewModel.CategoryId));
                cmd.Parameters.Add(new MySqlParameter("@CountAnswers", 5));
                cmd.Parameters.Add(new MySqlParameter("@NumberQuestion", 1));

                conn.Open();
                MySqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                while (sqlDataReader.Read())
                {
                    answers.Add(new CorrectAnswerViewModelRecord(
                        new CorrectAnswerViewModel
                        {
                            CorrectAnswerId = sqlDataReader.GetString(0),
                            QuestionId = sqlDataReader.GetString(1),
                            TitleEn = sqlDataReader.GetString(2),
                            TitleEs = sqlDataReader.GetString(3),
                            TitleRu = sqlDataReader.GetString(4),
                            CreaterId = sqlDataReader.GetString(5),
                            IsTerm = sqlDataReader.GetInt16(7)
                        },
                        Guid.NewGuid()));
                }
            }
        }

        var result = answers.OrderBy(i => i.guid).Select(i => i.model).ToList();
        return result;
    }

    public async Task<List<CorrectAnswerViewModel>> GetCorrectAnswersForSpeakAsync(
        ApplicationDbContext context,
        QuestionViewModel questionViewModel,
        CancellationToken cancellationToken)
    {
#if DEBUG
        logger.LogInformation("StartTest->GetAnswers");
        logger.LogInformation("QuestionsId {0}", questionViewModel.QuestionId);
        logger.LogInformation("IsTerm {0}", questionViewModel.IsTerm);
        logger.LogInformation("CategoryId {0}", questionViewModel.CategoryId);
#endif
        var listCorrectAnswer = await (
                from questions in context.Questions
                join questionAndCorrectAnswer in context.QuestionsAndCorrectAnswers
                    on questions.Id equals questionAndCorrectAnswer.QuestionId
                join correctAnswer in context.CorrectAnswers
                    on questionAndCorrectAnswer.CorrectAnswerId equals correctAnswer.Id
                where questions.Id == questionViewModel.QuestionId
                select new CorrectAnswerViewModel()
                {
                    CorrectAnswerId = correctAnswer.Id,
                    QuestionId = questions.Id,
                    TitleEn = correctAnswer.TitleEn,
                    TitleEs = correctAnswer.TitleEs,
                    TitleRu = correctAnswer.TitleRu,
                    CreaterId = correctAnswer.CreaterId,
                    IsTerm = correctAnswer.IsTerm
                })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return listCorrectAnswer;
    }

    record CorrectAnswerViewModelRecord(CorrectAnswerViewModel model, Guid guid);
}