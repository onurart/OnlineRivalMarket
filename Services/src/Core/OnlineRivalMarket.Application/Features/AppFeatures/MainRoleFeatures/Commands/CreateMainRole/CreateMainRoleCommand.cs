namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
public sealed record CreateMainRoleCommand(string Title) : ICommand<CreateMainRoleCommandResponse>;