using AutoMapper;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Services.TestService.Commands;
using Services.TestService.Commands.GetPreSignedURL;
using Services.TestService.Commands.StartTest;
using Services.TestService.Queries.GetNextQuestionsByCategoryId;

namespace Services.TestService;

public class TestService(
    ILogger<TestService> logger,
    IMediator mediator) : BaseService(
    logger,
    mediator), ITestService
{
    public async Task<NextQuestionViewModel?> GetNextQuestionsByCategoryIdAsync(string language, string userId,
        NextQuestionViewModelRequest request, CancellationToken cancellationToken)
    {
        const string errMessage = "Executed GetNextQuestionsByCategoryIdAsync failed";

        try
        {
            var result = await Mediator.Send(
                new GetNextQuestionsByCategoryId
                {
                    Lang = language,
                    UserId = userId,
                    Request = request,
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

    public async Task<StartTestViewModel?> StartTestAsync(string language, string userId,
        StartTestViewModelRequest request,
        CancellationToken cancellationToken)
    {
        const string errMessage = "Executed StartTestAsync failed";

        try
        {
            var result = await Mediator.Send(
                new StartTestCommand
                {
                    Lang = language,
                    UserId = userId,
                    StartTestViewModel = request.ToStartTestViewModel(),
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
}