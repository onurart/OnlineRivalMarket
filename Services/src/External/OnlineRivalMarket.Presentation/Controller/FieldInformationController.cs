﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries;
using OnlineRivalMarket.Presentation.Abstraction;
namespace OnlineRivalMarket.Presentation.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FieldInformationController : ApiController
    {
        public FieldInformationController(IMediator mediator) : base(mediator)
        {
        }
        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateFieldInformation(CreateFieldInformationCommand requst, CancellationToken cancellationToken)
        //{
        //    CreateFieldInformationCommandResponse response = await _mediator.Send(requst, cancellationToken);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{companyid}")]
        //public async Task<IActionResult> GetAllFieldInformation(string companyid)
        //{
        //    GetAllFieldInformationQuery requst = new(companyid);
        //    GetAllFieldInformationQueryReponse response = await _mediator.Send(requst);
        //    return Ok(response);
        //}


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateFieldInformation(CreateFieldInformationCommand request, CancellationToken cancellationToken)
        {
            CreateFieldInformationCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllFieldInformation(string companyid)
        {
            GetAllFieldInformationQuery request = new(companyid);
            GetAllFieldInformationQueryReponse reponse = await _mediator.Send(request);
            return Ok(reponse);
        }
        }
}
    


