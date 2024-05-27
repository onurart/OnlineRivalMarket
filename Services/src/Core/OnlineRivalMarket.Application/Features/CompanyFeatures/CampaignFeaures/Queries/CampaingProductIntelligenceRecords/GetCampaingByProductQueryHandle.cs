
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.CampaingProductIntelligenceRecords;
public class GetCampaingByProductQueryHandle : IQueryHandler<GetCampaingByProductQuery, GetCampaingByProductQueryResponse>
{
    private readonly ICampaignService _campaignService;

    public GetCampaingByProductQueryHandle(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }

    public async Task<GetCampaingByProductQueryResponse> Handle(GetCampaingByProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignService.GetByCampaingProductIntelligenceRecordsAsync(request.id, request.CompandId);
        return new GetCampaingByProductQueryResponse(result);

    }
}
