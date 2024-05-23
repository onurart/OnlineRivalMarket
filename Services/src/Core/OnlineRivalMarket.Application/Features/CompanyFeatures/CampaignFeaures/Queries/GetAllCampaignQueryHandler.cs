namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
public sealed class GetAllCampaignQueryHandler : IQueryHandler<GetAllCampaignQuery, GetAllCampaignQueryResponse>
{
    private readonly ICampaignService _campaignService;
    public GetAllCampaignQueryHandler(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }

    public Task<GetAllCampaignQueryResponse> Handle(GetAllCampaignQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
