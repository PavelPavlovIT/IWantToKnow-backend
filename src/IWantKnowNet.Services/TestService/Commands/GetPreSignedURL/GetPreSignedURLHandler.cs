using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using IWantKnowNet.Data.Repositories.Question;
using IWantKnowNet.Data.Repositories.TestRepository;
using IWantToKnowNet.Common.Utils;
using IWantToKnowNet.Common.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.Xml;

namespace Services.TestService.Commands.GetPreSignedURL
{
    public class GetPreSignedURLHandler(
        IConfiguration configuration,
        IQuestionRepository repository) 
        : IRequestHandler<GetPreSignedURLCommand, (string,DateTime)>
    {
        public async Task<(string, DateTime)> Handle(GetPreSignedURLCommand request,
            CancellationToken cancellationToken)
        {
            var result = (SignedURL: "", ExpiredDate: DateTime.UtcNow.AddHours(double.Parse(configuration["ExpiresIn"]!)));

            //TODO put to user secrets
            var credentials = new BasicAWSCredentials(
                configuration["AwsApiAccessKey"], 
                configuration["AwsApiSecretKey"]);
            IAmazonS3 clientS3 = new AmazonS3Client(credentials, RegionEndpoint.SAEast1);
            
            var getPreSignedUrlRequest = new GetPreSignedUrlRequest
            {
                BucketName = "iwanttoknow-translations",
                Key = request.Key,
                Verb = HttpVerb.GET,
                Expires = result.ExpiredDate,
            };

            result.SignedURL = await clientS3.GetPreSignedURLAsync(getPreSignedUrlRequest);

            await repository!.UpdateExpiredSignedUrlS3InQuestionAsync(
                request.QuestionId,
                result.SignedURL,
                result.ExpiredDate,
                cancellationToken);

            return result;
        }
    }
}