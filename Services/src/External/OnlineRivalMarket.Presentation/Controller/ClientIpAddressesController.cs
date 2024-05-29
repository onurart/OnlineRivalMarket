using OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Create.Create;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Create.UpdateProduct;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ClientIpAddresses.Commands.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Presentation.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ClientIpAddressesController : ApiController
    {
        public ClientIpAddressesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateIpAdresses([FromForm] CreateClientIpAddressCommand requst, CancellationToken cancellationToken)
        {
            CreateClientIpAddressResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetIpAdresses(string companyid)
        {
            GetlAllIpAdressesQuery requst = new(companyid);
            GetAllIpAdressesResponse response = await _mediator.Send(requst);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatepdIAdresses(UpdatedDateCommand request, CancellationToken cancellationToken)
        {
            UpdateDateResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
