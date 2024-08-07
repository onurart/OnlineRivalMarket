﻿namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.CampaignGetById
{
    public sealed class GetByIdGetByIdCampaignHandler : IQueryHandler<GetByIdCampaignQuery, GetByIdGetByIdCampaignResponse>
    {
        private readonly ICampaignService _service;

        public GetByIdGetByIdCampaignHandler(ICampaignService service)
        {
            _service = service;
        }

        public async Task<GetByIdGetByIdCampaignResponse> Handle(GetByIdCampaignQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetListByIdDtoAsync(request.id,request.CompanyId);
            return new GetByIdGetByIdCampaignResponse(result);
        }
    }
}
