﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries;
using OnlineRivalMarket.Presentation.Abstraction;
namespace OnlineRivalMarket.Presentation.Controller
{
    public class ProductController : ApiController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand request, CancellationToken cancellationToken)
        {
            CreateProductCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllProduct(string companyid)
        {
            GetAllProductQuery request = new(companyid);
            GetAllProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
       
            
    }
}