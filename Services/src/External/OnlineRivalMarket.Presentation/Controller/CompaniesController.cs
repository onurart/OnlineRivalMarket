namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]
public class CompaniesController : ApiController
{
    public CompaniesController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        CreateCompanyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> MigrateCompanyDatabases()
    {
        MigrateCompanyDatabasesCommand request = new();
        MigrateCompanyDatabasesCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllCompany()
    {
        GetAllCompanyQuery request = new();
        GetAllCompanyQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }
    //[HttpPost("[action]")]
    //public async Task<IActionResult> Update(UpdateCompanyCommand request)
    //{
    //    UpdateCompanyCommandResponse response = await _mediator.Send(request);
    //    return Ok(response);
    //}
    //[HttpPost("[action]")]
    //public async Task<IActionResult> UpdateLogo(UpdatePhotoCompanyCommand request)
    //{
    //    UpdatePhotoCompanyCommandResponse response = await _mediator.Send(request);
    //    return Ok(response);
    //}
}
