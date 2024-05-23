namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
public sealed record GetAllCampaignQuery(string CompanyId, int PageNumber = 0, int PageSize = 10) : IQuery<GetAllCampaignQueryResponse>;
