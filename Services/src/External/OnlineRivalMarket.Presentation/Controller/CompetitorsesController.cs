using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors;
using OnlineRivalMarket.Presentation.Abstraction;
namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]
public class CompetitorsesController : ApiController
{
    public CompetitorsesController(IMediator mediator) : base(mediator){}
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCompetitorses(CreateCompetitorsCommand request, CancellationToken cancellationToken)
    {
        CreateCompetitorsCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetAllCompetitor(string companyid)
    {
        GetAllCampaignQuery request = new(companyid);
        GetAllCampaignQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
