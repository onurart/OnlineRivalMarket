﻿using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.AppServices;
using OnlineRivalMarket.Domain.AppEntities.Identity;
namespace OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCommandResponse>
{
    private readonly IRoleService _roleService;
    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        AppRole role = await _roleService.GetByCode(request.Code);
        if (role != null) throw new Exception("Bu rol daha önce kayıt edilmiş!");

        await _roleService.AddAsync(request);
        return new();
    }
}