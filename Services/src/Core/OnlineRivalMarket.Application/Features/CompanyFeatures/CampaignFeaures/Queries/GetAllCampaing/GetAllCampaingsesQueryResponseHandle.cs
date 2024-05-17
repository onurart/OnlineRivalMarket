using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllCampaing
{
    public sealed class GetAllCampaingsesQueryResponseHandle : IQueryHandler<GetAllCampaingsesQuery, GetAllCampaingsesQueryResponse>
    {
        private readonly ICampaignService _campaignService;

        public GetAllCampaingsesQueryResponseHandle(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<GetAllCampaingsesQueryResponse> Handle(GetAllCampaingsesQuery request, CancellationToken cancellationToken)
        {
            return new(await _campaignService.GetAllCampaingAsync(request.CompanyId));
        }
    }
}
