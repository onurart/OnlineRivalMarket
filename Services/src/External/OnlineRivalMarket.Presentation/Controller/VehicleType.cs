namespace OnlineRivalMarket.Presentation.Controller;
[Authorize(AuthenticationSchemes = "Bearer")]
public class VehicleType : ApiController
{
    public VehicleType(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateVehicleType(CreateVehicleTypeCommand requst, CancellationToken cancellationToken)
    {
        CreateVehicleTypeCommandResponse response = await _mediator.Send(requst, cancellationToken);
        return Ok(response);
    }
    [HttpGet("[action]/{companyId}")]
    public async Task<IActionResult> GetAllVehicleType(string companyId)
    {
        GetAllVehicleTypeQuery requst = new(companyId);
        GetAllVehicleTypeQueryResponse response = await _mediator.Send(requst);
        return Ok(response);
    }

}
