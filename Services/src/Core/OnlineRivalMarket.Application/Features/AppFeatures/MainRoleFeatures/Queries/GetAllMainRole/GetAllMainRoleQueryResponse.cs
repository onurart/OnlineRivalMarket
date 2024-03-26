using OnlineRivalMarket.Domain.AppEntities;
namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;
public sealed record GetAllMainRoleQueryResponse(IList<MainRole> MainRoles);