﻿using OnlineRivalMarket.Domain.AppEntities.Identity;
namespace OnlineRivalMarket.Application.Features.AppFeatures.UserRoleFeatures.Queries.GetAllUserRoles;
public sealed record GetAllUserRolesQueryResponse(IList<AppUserRole> AppUserRoles);