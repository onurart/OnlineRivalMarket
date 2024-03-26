using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;
public sealed record CreateStaticRolesCommand() : ICommand<CreateStaticRolesCommandResponse>;