﻿namespace OnlineRivalMarket.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
public sealed class CreateMainRoleAndUserRLCommandHandler : ICommandHandler<CreateMainRoleAndUserRLCommand, CreateMainRoleAndUserRLCommandResponse>
{
    private readonly IMainRoleAndUserRelationshipService _service;
    public CreateMainRoleAndUserRLCommandHandler(IMainRoleAndUserRelationshipService service)
    {
        _service = service;
    }
  


    public async Task<CreateMainRoleAndUserRLCommandResponse> Handle(CreateMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationship checkEntity = await _service.GetByUserIdCompanyIdAndMainRoleIdAsync(request.UserId, request.MainRoleId, cancellationToken);
        if (checkEntity != null)
        {

        }

        MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
            Guid.NewGuid().ToString(), request.UserId, request.MainRoleId);

        await _service.CreateAsync(mainRoleAndUserRelationship, cancellationToken);

        return new();
    }
}