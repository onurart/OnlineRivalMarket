using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.Queries.GetAllBrand;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries;
using OnlineRivalMarket.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Presentation.Controller
{
    public class FieldInformationController : ApiController
    {
        public FieldInformationController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrand(CreateFieldInformationCommand requst, CancellationToken cancellationToken)
        {
            CreateFieldInformationCommandResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllBrand(string companyid)
        {
            GetAllFieldInformationQuery requst = new(companyid);
            GetAllFieldInformationQueryReponse response = await _mediator.Send(requst);
            return Ok(response);
        }


        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateFieldInformation(CreateFieldInformationCommand request, CancellationToken cancellationToken)
        //{
        //    CreateFieldInformationCommandResponse response = await _mediator.Send(request, cancellationToken);
        //    return Ok(response);
        //}
        //[HttpGet("[action]/{companyid}")]
        //public async Task<IActionResult> GetAllFieldInformation(string companyid)
        //{
        //    GetAllFieldInformationQuery request = new(companyid);
        //    GetAllFieldInformationQueryReponse reponse = await _mediator.Send(request);
        //    return Ok(reponse);
    }
}
    


