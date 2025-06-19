using AutoMapper;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Services.StudyService.Commands.StartStudy;
using Services.StudyService.Queries.CheckAnswerStudy;
using Services.StudyService.Queries.GetNextQuestionsForStudy;
using Services.TestService.Commands.GetPreSignedURL;

namespace Services.StudyService;

public class StudyService(
    IMapper mapper,
    ILogger<StudyService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator),  IStudyService
{
    public async Task<StartTestViewModel?> StartStudyAsync(string lang, string userId, string categoryId, string typeTestId, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed StartSudyAsync failed";

        try
        {
            var result = await Mediator.Send(
                new StartStudyCommand
                {
                    Lang = lang,
                    CategoryId = categoryId,
                    UserId = userId,
                    TypeTestId = typeTestId
                    //TODO CountQuestion need move to appsettings
                },
                cancellationToken);

            if (DateTime.UtcNow >= result!.NextQuestionViewModel!.QuestionViewModel.ExpiredSignedUrlS3)
            {
                var getPreSignedURLCommand = await Mediator.Send(
                    new GetPreSignedURLCommand
                    {
                        QuestionId = result!.NextQuestionViewModel!.QuestionViewModel.QuestionId,
                        Key = result!.NextQuestionViewModel!.QuestionViewModel.KeyS3!
                    },
                    cancellationToken);

                result!.NextQuestionViewModel!.QuestionViewModel.ExpiredSignedUrlS3 = getPreSignedURLCommand.Item2;
                result!.NextQuestionViewModel!.QuestionViewModel.SignedUrlS3 = getPreSignedURLCommand.Item1;
            }
            
            return result;

        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }
    }

    public async Task<bool> CheckAnswerStudyAsync(string language, string userId, NextQuestionViewModelRequest request, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed CheckAnswerStudyAsync failed";

        try
        {
            var result = await Mediator.Send(
                new CheckAnswerStudyQuery
                {
                    Lang = language,
                    Request = request,
                    UserId = userId,
                },
                cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return false;
        }
    }

    public async Task<NextQuestionViewModel?> GetNextQuestionsForStudyAsync(string lang, string userId, NextQuestionViewModelRequest request, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetNextQuestionsForStudyAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetNextQuestionsForStudyQuery
                {
                    Lang = lang,
                    Request = request,
                    UserId = userId,
                },
                cancellationToken);

            if (DateTime.UtcNow >= result!.QuestionViewModel.ExpiredSignedUrlS3)
            {
                var getPreSignedURLCommand = await Mediator.Send(
                    new GetPreSignedURLCommand
                    {
                        QuestionId = result!.QuestionViewModel.QuestionId,
                        Key = result!.QuestionViewModel.KeyS3!
                    },
                    cancellationToken);

                result!.QuestionViewModel.ExpiredSignedUrlS3 = getPreSignedURLCommand.Item2;
                result!.QuestionViewModel.SignedUrlS3 = getPreSignedURLCommand.Item1;
            }

            result!.NumberQuestion = request.NumberQuestion + 1;
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, errMessage);
            return null;
        }

    }
}