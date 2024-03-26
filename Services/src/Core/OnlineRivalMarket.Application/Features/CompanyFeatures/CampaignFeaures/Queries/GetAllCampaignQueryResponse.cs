using OnlineRivalMarket.Domain.CompanyEntities;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
public sealed record GetAllCampaignQueryResponse(IList<Campaigns> Data);

