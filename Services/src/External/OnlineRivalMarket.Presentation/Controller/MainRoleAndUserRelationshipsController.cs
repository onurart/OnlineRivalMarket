using OnlineRivalMarket.Presentation.Abstraction;
using OnlineRivalMarket.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
using OnlineRivalMarket.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByIdMainRoleAndUserRL;
using OnlineRivalMarket.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace OnlineRivalMarket.Presentation.Controller;
public class MainRoleAndUserRelationshipsController : ApiController
{
    public MainRoleAndUserRelationshipsController(IMediator mediator) : base(mediator) { }
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndUserRLCommand request)
    {
        CreateMainRoleAndUserRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> RevmoveById(RemoveByIdMainRoleAndUserRLCommand request)
    {
        RemoveByIdMainRoleAndUserRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllMainRoleAndUserQuery request = new();
        GetAllMainRoleAndUserQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}