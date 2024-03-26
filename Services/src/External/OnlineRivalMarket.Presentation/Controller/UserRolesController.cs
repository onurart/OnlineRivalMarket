using OnlineRivalMarket.Presentation.Abstraction;
using OnlineRivalMarket.Application.Features.AppFeatures.UserRoleFeatures.Commands.CreateUserRole;
using OnlineRivalMarket.Application.Features.AppFeatures.UserRoleFeatures.Queries.GetAllUserRoles;
using OnlineRivalMarket.Application.Features.AppFeatures.UserRoleFeatures.Queries.GetUserRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]

public class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        CreateUserRoleCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllUserRoles(GetAllUserRolesQuery request)
    {
        GetAllUserRolesQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetByUserIdRoles(GetUserRolesQuery request)
    {
        GetUserRolesQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}