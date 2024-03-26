using OnlineRivalMarket.Presentation.Abstraction;
using OnlineRivalMarket.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace OnlineRivalMarket.Presentation.Controller;

[Authorize(AuthenticationSchemes = "Bearer")]
public class LogsController : ApiController
{
    public LogsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetLogsByTableName(GetLogsByTableNameQuery request)
    {
        GetLogsByTableNameQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}