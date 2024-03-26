using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
public sealed class GetAllCampaignQueryHandler : IQueryHandler<GetAllCampaignQuery, GetAllCampaignQueryResponse>
{
    private readonly ICampaignService _campaignService;
    public GetAllCampaignQueryHandler(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }
    public async Task<GetAllCampaignQueryResponse> Handle(GetAllCampaignQuery request, CancellationToken cancellationToken)
    {
        return new(await _campaignService.GetAllAsync(request.CompanyId));
    }
}
