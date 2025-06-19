using IWantToKnowNet.Common.ViewModels;
using MediatR;

namespace Services.TestService.Commands.StartTest;

public class StartTestCommand: IRequest<StartTestViewModel?>
{
    public string Lang { get; set; }
    public string UserId { get; set; } 
    public StartTestViewModel StartTestViewModel{ get; set; }
}