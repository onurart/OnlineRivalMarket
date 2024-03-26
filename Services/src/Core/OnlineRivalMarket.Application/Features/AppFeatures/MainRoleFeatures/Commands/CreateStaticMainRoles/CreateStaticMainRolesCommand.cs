using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.AppEntities;
namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;
public sealed record CreateStaticMainRolesCommand(List<MainRole> MainRoles) : ICommand<CreateStaticMainRolesCommandResponse>;