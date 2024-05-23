namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.HomeTopGetAll;
public sealed record GetTopAllCampaingQuery(string CompanyId) : IQuery<GetTopAllCampaingQueryResponse>;
