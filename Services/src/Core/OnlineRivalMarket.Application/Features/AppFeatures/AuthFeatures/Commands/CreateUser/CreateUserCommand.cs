namespace OnlineRivalMarket.Application.Features.AppFeatures.AuthFeatures.Commands.CreateUser;
public sealed record CreateUserCommand(string FirstName, string LastName, string UserName, string Email, string NameLastName, string Password) : ICommand<CreateUserCommandResponse>;
