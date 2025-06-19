using IWantKnowNet.Data.Repositories.TestRepository;
using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TestService.Queries.GetNextQuestionsByCategoryId;

public class GetNextQuestionsByCategoryIdHandler(ITestRepository repository) 
    : IRequestHandler<GetNextQuestionsByCategoryId, NextQuestionViewModel?>
{
    public async Task<NextQuestionViewModel?> Handle(GetNextQuestionsByCategoryId request,
        CancellationToken cancellationToken)
    {
        return await repository!.GetNextQuestionsByCategoryIdAsync(
            request.Lang,
            request.UserId,
            request.Request,
            cancellationToken);
    }
}