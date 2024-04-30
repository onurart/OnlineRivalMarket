using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Commands.CreateVehicleGroup;
using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Queries;
using OnlineRivalMarket.Presentation.Abstraction;

namespace OnlineRivalMarket.Presentation.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class VehicleGroupController : ApiController
    {
        public VehicleGroupController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateVehicleGroup(CreateVehicleGroupCommand requst,CancellationToken cancellationToken)
        {
            CreateVehicleGroupCommandResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllVehicleGroup(string companyid)
        {
            GetAllVehicleGroupQuery request = new(companyid);
            GetAllVehicleGroupQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
