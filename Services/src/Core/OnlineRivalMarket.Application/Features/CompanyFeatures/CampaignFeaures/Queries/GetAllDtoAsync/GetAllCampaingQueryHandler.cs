namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;

public sealed class GetAllCampaingQueryHandler : IQueryHandler<GetAllDtoAsyncQuery, GetAllCampaingDtoResponse>
{
    private readonly ICampaignService _service;
    public GetAllCampaingQueryHandler(ICampaignService service)
    {
        _service = service;
    }
    public async Task<GetAllCampaingDtoResponse> Handle(GetAllDtoAsyncQuery request, CancellationToken cancellationToken)
    {
        return new(await _service.GetAllDtoAsync(request));
    }
}
