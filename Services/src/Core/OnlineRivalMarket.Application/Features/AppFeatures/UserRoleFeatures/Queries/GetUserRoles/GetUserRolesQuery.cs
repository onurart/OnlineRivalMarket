using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.AppFeatures.UserRoleFeatures.Queries.GetUserRoles;
public sealed record GetUserRolesQuery(string UserId) : IQuery<GetUserRolesQueryResponse>;