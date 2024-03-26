using OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
public sealed record CreateMainRoleCommand(string Title) : ICommand<CreateMainRoleCommandResponse>;