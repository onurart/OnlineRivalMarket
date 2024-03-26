using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;
public sealed record RemoveByIdMainRoleCommand(string Id) : ICommand<RemoveByIdMainRoleCommandResponse>;