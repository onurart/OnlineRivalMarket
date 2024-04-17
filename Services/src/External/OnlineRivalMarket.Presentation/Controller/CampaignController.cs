using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.HomeTopGetAll;
using OnlineRivalMarket.Presentation.Abstraction;
namespace OnlineRivalMarket.Presentation.Controller
{
    public class CampaignController : ApiController
    {
        public CampaignController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCampaign(CreateCampaignCommand requst, CancellationToken cancellationToken)
        {
            CreateCampaignCommandResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllCampaignDto(string companyid)
        {
            GetAllCampaignQuery requst = new(companyid);
            GetAllCampaignQueryResponse response = await _mediator.Send(requst);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetTopAllCampaignDto(string companyid)
        {
            GetTopAllCampaingQuery requst = new(companyid);
            GetTopAllCampaingQueryResponse response = await _mediator.Send(requst);
            return Ok(response);
        }
    }
}
