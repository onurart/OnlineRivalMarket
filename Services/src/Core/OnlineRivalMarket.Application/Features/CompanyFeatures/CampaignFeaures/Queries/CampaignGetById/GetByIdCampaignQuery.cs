using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.CampaignGetById;
public sealed record GetByIdCampaignQuery(string id, string CompanyId) : IQuery<GetByIdGetByIdCampaignResponse>;

