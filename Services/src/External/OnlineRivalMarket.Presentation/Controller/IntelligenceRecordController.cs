namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]
public class IntelligenceRecordController : ApiController
{
    public IntelligenceRecordController(IMediator mediator) : base(mediator)
    {
    }
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,USER")]
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateIntelligenceRecord([FromForm] CreateIntelligenceRecordCommand request, CancellationToken cancellationToken)
    {
        CreateIntelligenceRecordCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,VIEWER,USER")]
    [HttpGet("[action]/{id}/{companyId}")]
    public async Task<IActionResult> GetByIdIntelligenceRecord(string id, string companyId)
    {
        GetByIdIntelligenceRecordQuery request = new(id, companyId);
        GetByIdIntelligenceRecordQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,VIEWER,USER")]
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> GetIntelligenceRecordDto(string companyid)
    {
        IntelligenceRecordDtoQuery requst = new(companyid);
        IntelligenceRecordDtoQueryResponse reponse = await _mediator.Send(requst);
        return Ok(reponse);

    }
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,VIEWER,USER")]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetIntelligenceRecordDtoFilter(GetAllDtoFilterIntelligenceRecordQuery requst, CancellationToken cancellationToken)
    {
        var reponse = await _mediator.Send(requst);
        return Ok(reponse);

    }
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,VIEWER,USER")]
    [HttpGet("[action]/{companyid}")]
    public async Task<IActionResult> HomeGetIntelligenceRecordDto(string companyid)
    {
        HomeGetTopIntelligenceRecordQuery requst = new(companyid);
        HomeGetTopIntelligenceRecordQueryResponse reponse = await _mediator.Send(requst);
        return Ok(reponse);

    }
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN,VIEWER,USER")]
    [HttpGet("[action]/{id}/{companyId}")]
    public async Task<IActionResult> GetByProductIdIntelligenceRecordsAsync(string id, string companyId)
    {
        GetByProductIdIntelligenceQuery request = new(id, companyId);
        GetByProductIdIntelligenceResponse response = await _mediator.Send(request);
        return Ok(response);

    }
}
