﻿using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.HomeTopGetAll
{
    public sealed class GetTopAllCampaingQueryHandler : IQueryHandler<GetTopAllCampaingQuery, GetTopAllCampaingQueryResponse>
    {
        private readonly ICampaignService _campaignService;

        public GetTopAllCampaingQueryHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<GetTopAllCampaingQueryResponse> Handle(GetTopAllCampaingQuery request, CancellationToken cancellationToken)
        {
            return new(await _campaignService.HomeTopGetAllDtoAsync(request.CompanyId));
        }
    }
}
