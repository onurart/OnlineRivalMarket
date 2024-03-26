using OnlineRivalMarket.Presentation.Abstraction;
using OnlineRivalMarket.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using OnlineRivalMarket.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]

public class UserAndCompanyRelationshipsController : ApiController
{
    public UserAndCompanyRelationshipsController(IMediator mediator) : base(mediator) { }
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserAndCompanyRLCommand request, CancellationToken cancellationToken)
    {
        CreateUserAndCompanyRLCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveById(RemoveByIdUserAndCompanyRLCommand request)
    {
        RemoveByIdUserAndCompanyRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}