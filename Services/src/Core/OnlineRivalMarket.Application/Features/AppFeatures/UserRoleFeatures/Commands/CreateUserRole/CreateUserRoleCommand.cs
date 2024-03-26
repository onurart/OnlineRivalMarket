﻿using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.AppFeatures.UserRoleFeatures.Commands.CreateUserRole;
public sealed record CreateUserRoleCommand(string RoleId, string UserId) : ICommand<CreateUserRoleCommandResponse>;