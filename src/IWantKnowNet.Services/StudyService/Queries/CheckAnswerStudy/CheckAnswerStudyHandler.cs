using IWantKnowNet.Data.Repositories.StudyRepository;
using MediatR;

namespace Services.StudyService.Queries.CheckAnswerStudy;

public class CheckAnswerStudyHandler(
    IStudyBySpeakRepositoryEasyLevel bySpeakRepositoryEasyLevel,
    IStudyBySpeakRepositoryMediumLevel bySpeakRepositoryMediumLevel,
    IStudyBySpeakRepositoryDifficultLevel bySpeakRepositoryDifficultLevel,
    IStudyByListenRepository repositoryByListen,
    IStudyByReadRepository repositoryByRead)
    : IRequestHandler<CheckAnswerStudyQuery, bool>
{
    public async Task<bool> Handle(
        CheckAnswerStudyQuery request,
        CancellationToken cancellationToken)
    {
        switch (request.Request.TypeTestId)
        {
            case "2c4286c2-a0f5-4a72-861c-12829546981b":
                return await repositoryByListen!.CheckAnswerStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            case "dbf39bef-b195-48c8-b328-d1087e085e18":
                return await repositoryByRead!.CheckAnswerStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            case "80907d2b-8387-4d4d-b7d6-1bc7d617d1bb":
                return await bySpeakRepositoryEasyLevel!.CheckAnswerStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            case "1928f7d7-225f-4c32-b3f8-4786dc3dffee":
                return await bySpeakRepositoryMediumLevel!.CheckAnswerStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            // case "930c9e4a-60cc-462a-9b4a-0f2e6b263932":
            default: 
                return await bySpeakRepositoryDifficultLevel!.CheckAnswerStudyAsync(
                    request.Lang,
                    request.UserId,
                    request.Request,
                    cancellationToken);
            
        }

    }
}