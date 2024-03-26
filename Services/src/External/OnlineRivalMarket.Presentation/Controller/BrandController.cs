using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.Queries.GetAllBrand;
using OnlineRivalMarket.Presentation.Abstraction;
namespace OnlineRivalMarket.Presentation.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class BrandController : ApiController
    {
        public BrandController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand requst, CancellationToken cancellationToken)
        {
            CreateBrandCOmmandResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllBrand(string companyid)
        {
            GetAllBrandQuery requst = new(companyid);
            GetAllBrandQueryResponse response = await _mediator.Send(requst);
            return Ok(response);
        }
    }
}
