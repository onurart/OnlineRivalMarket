using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllIntelligenceRecord;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.HomeGetTopIntelligenceRecord;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.IntelligenceRecordDtos;
using OnlineRivalMarket.Presentation.Abstraction;

namespace OnlineRivalMarket.Presentation.Controller
{
    public class IntelligenceRecordController : ApiController
    {
        public IntelligenceRecordController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateIntelligenceRecord(CreateIntelligenceRecordCommand request,CancellationToken cancellationToken)
        {
            CreateIntelligenceRecordCommandResponse response = await _mediator.Send(request,cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllIntelligenceRecord(string companyid)
        {
            GetAllIntelligenceRecordQuery requst = new(companyid);
            GetAllIntelligenceRecordQueryResponse response = await _mediator.Send(requst);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetIntelligenceRecordDto(string companyid)
        {
            IntelligenceRecordDtoQuery requst = new(companyid);
            IntelligenceRecordDtoQueryResponse reponse =await _mediator.Send(requst);   
            return Ok(reponse);

        }

        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> HomeGetIntelligenceRecordDto(string companyid)
        {
            HomeGetTopIntelligenceRecordQuery requst = new(companyid);
            HomeGetTopIntelligenceRecordQueryResponse reponse = await _mediator.Send(requst);
            return Ok(reponse);

        }

    }
}
