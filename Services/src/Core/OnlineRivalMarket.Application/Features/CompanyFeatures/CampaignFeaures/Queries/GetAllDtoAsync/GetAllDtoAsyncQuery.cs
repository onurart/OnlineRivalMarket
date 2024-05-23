namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;
public sealed record GetAllDtoAsyncQuery(string CompanyId, int PageNumber=1, int PageSize = 10) : IQuery<GetAllCampaingDtoResponse>;
    
