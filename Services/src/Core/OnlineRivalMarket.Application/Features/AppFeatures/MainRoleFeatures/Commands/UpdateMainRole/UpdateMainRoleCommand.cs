using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
public sealed record UpdateMainRoleCommand(string Id, string Title) : ICommand<UpdateMainRoleCommandResponse>;