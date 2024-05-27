namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.CampaingProductIntelligenceRecords;
public sealed record GetCampaingByProductQuery (string id, string CompandId) : IQuery<GetCampaingByProductQueryResponse>;
