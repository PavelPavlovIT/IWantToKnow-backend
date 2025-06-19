using IWantKnowNet.Data.Repositories.StudyRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.StudyService.Queries.GetNextQuestionsForStudy;

public class GetNextQuestionsForStudyHandler(
    IStudyBySpeakRepositoryEasyLevel bySpeakRepositoryEasyLevel,
    IStudyBySpeakRepositoryMediumLevel bySpeakRepositoryMediumLevel,
    IStudyBySpeakRepositoryDifficultLevel bySpeakRepositoryDifficultLevel,
    IStudyByListenRepository repositoryByListen,
    IStudyByReadRepository repositoryByRead)
    : IRequestHandler<GetNextQuestionsForStudyQuery, NextQuestionViewModel?>
{
    public async Task<NextQuestionViewModel?> Handle(
        GetNextQuestionsForStudyQuery request,
        CancellationToken cancellationToken)
    {
        switch (request.Request.TypeTestId)
        {
            case "2c4286c2-a0f5-4a72-861c-12829546981b":
                return await repositoryByListen!.GetNextQuestionsForStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            case "dbf39bef-b195-48c8-b328-d1087e085e18":
                return await repositoryByRead!.GetNextQuestionsForStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            case "80907d2b-8387-4d4d-b7d6-1bc7d617d1bb":
                return await bySpeakRepositoryEasyLevel!.GetNextQuestionsForStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            case "1928f7d7-225f-4c32-b3f8-4786dc3dffee":
                return await bySpeakRepositoryMediumLevel!.GetNextQuestionsForStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            // case "930c9e4a-60cc-462a-9b4a-0f2e6b263932":
            default: 
                return await bySpeakRepositoryDifficultLevel!.GetNextQuestionsForStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
        }

    }
}