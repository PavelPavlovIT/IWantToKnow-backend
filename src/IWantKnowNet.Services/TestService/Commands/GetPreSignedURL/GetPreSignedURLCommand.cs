using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TestService.Commands.GetPreSignedURL
{
    public class GetPreSignedURLCommand : IRequest<(string,DateTime)>
    {
        public required string QuestionId { get; set; }
        public required string Key { get; set; }
    }
}