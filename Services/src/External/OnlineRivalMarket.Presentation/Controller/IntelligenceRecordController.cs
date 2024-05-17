using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetByIdIntelligenceRecord;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetFilteredIntelligenceRecordsAsync;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.HomeGetTopIntelligenceRecord;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.IntelligenceRecordDtos;
using OnlineRivalMarket.Presentation.Abstraction;
namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]
public class IntelligenceRecordController : ApiController
{
    public IntelligenceRecordController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateIntelligenceRecord([FromForm] CreateIntelligenceRecordCommand request,CancellationToken cancellationToken)
    {
        CreateIntelligenceRecordCommandResponse response = await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }
    [HttpGet("[action]/{id}/{companyId}")]
    public async Task<IActionResult> GetByIdIntelligenceRecord(string id, string companyId)
    {
        GetByIdIntelligenceRecordQuery request = new(id, companyId);
        GetByIdIntelligenceRecordQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    //[HttpGet("[action]/{companyid}")]
    //public async Task<IActionResult> GetAllIntelligenceRecord(string companyid)
    //{
    //    GetAllIntelligenceRecordQuery requst = new(companyid);
    //    GetAllIntelligenceRecordQueryResponse response = await _mediator.Send(requst);
    //    return Ok(response);
    //}
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetIntelligenceRecordDto(string companyid)
    {
        IntelligenceRecordDtoQuery requst = new(companyid);
        IntelligenceRecordDtoQueryResponse reponse =await _mediator.Send(requst);   
        return Ok(reponse);

    }
    [HttpGet("[action]/{companyId}")]
    public async Task<IActionResult> GetFilteredIntelligenceRecords(string companyId, [FromQuery] IList<string> competitorIds)
    {
        try
        {
            var query = new IntelligenceRecordFilterQuery(companyId, competitorIds);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            // Hata durumunda uygun yanıtı döndür
            return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
        }
    }

    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> HomeGetIntelligenceRecordDto(string companyid)
    {
        HomeGetTopIntelligenceRecordQuery requst = new(companyid);
        HomeGetTopIntelligenceRecordQueryResponse reponse = await _mediator.Send(requst);
        return Ok(reponse);

    }

}
