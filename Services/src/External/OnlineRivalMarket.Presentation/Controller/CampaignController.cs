using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.CampaingProductIntelligenceRecords;

namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]
public class CampaignController : ApiController
{
    public CampaignController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCampaign([FromForm]CreateCampaignCommand requst, CancellationToken cancellationToken)
    {
        CreateCampaignCommandResponse response = await _mediator.Send(requst, cancellationToken);
        return Ok(response);
    }
    //[HttpPost("[action]")]
    //public async Task<IActionResult> GetAllCampaignDto(GetAllCampaignQuery requst)
    //{
    //    GetAllCampaignQueryResponse response = await _mediator.Send(requst);
    //    return Ok(response);
    //}
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetTopAllCampaignDto(string companyid)
    {
        GetTopAllCampaingQuery requst = new(companyid);
        GetTopAllCampaingQueryResponse response = await _mediator.Send(requst);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllDtoAsync(GetAllDtoAsyncQuery requst)
    {
        GetAllCampaingDtoResponse response = await _mediator.Send(requst);
        return Ok(response);
    }
    [HttpGet("[action]/{id}/{companyId}")]
    public async Task<IActionResult> GetByIdTCampaing(string id, string companyId)
    {
        GetByIdCampaignQuery request = new(id,companyId);
        GetByIdGetByIdCampaignResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetAllCampaingsesAsync(string companyid)
    {
        GetAllCampaingsesQuery requst = new(companyid);
        GetAllCampaingsesQueryResponse response = await _mediator.Send(requst);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> GetCampaingDtoFilter(GetAllDtoFilterCampaingsQuery requst, CancellationToken cancellationToken)
    {
        var reponse = await _mediator.Send(requst);
        return Ok(reponse);

    }
    [HttpGet("[action]/{id}/{companyId}")]
    public async Task<IActionResult> GetByCampaingProduct(string id, string companyId)
    {
        GetCampaingByProductQuery request = new(id,companyId);
        GetCampaingByProductQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
