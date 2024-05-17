using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.Queries.GetAllCategory;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Commamds;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Queries.GetAllForeignCurrency.GetAllForeignCurrency;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Queries.GetAllForeignCurrency.GetAllForeignCurrencyDtoAsync;
using OnlineRivalMarket.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Presentation.Controller
{
    [Authorize(AuthenticationSchemes = "Bearer")]

    public class ForeignCurrencyController : ApiController
    {
        public ForeignCurrencyController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateForeignCurrency(CreateForeignCurrencyCommand requst, CancellationToken cancellationToken)
        {
            CreateForeignCurrencyCommandResponse response = await _mediator.Send(requst, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllForeignCurrency(string companyid)
        {
            GetAllForeignCurrencyQuery request = new(companyid);
            GetAllForeignCurrencyResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{companyid}")]
        public async Task<IActionResult> GetAllForeignCurrencyDto(string companyid)
        {
            GetAllForeignCurrencyDtoQuery request = new(companyid);
            GetAllForeignCurrencyDtoQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
