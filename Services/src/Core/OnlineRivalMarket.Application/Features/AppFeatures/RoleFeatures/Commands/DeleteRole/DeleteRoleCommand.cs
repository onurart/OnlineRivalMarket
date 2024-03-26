using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
public sealed record DeleteRoleCommand(string Id) : ICommand<DeleteRoleCommandResponse>;