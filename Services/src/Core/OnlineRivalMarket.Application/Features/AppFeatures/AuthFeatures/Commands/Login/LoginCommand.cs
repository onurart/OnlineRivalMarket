namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.Login;
public sealed record LoginCommand(string EmailOrUserName, string Password) : ICommand<Result<LoginCommandResponse>>;
