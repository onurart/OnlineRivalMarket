using OnlineRivalMarket.Presentation.Abstraction;
using OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRoles;
using OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineRivalMarket.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]

public class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRole(CreateRoleCommand request)
    {
        CreateRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetlAllRoles()
    {
        GetAllRolesQuery request = new();
        GetAllRolesQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateRole(UpdateRoleCommand request)
    {
        UpdateRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> DeleteRole(string id)
    {
        DeleteRoleCommand request = new(id);
        DeleteRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> CreateAllRoles()
    {
        CreateStaticRolesCommand request = new();
        CreateStaticRolesCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}