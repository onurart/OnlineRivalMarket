using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Dtos;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoFilterCampaings;

public sealed record GetAllDtoFilterCampaingsQuery(
    string companyId,
    List<string> competitorIds,
    List<string> productIds,
    List<string> brandIds,
    List<string> categoryIds,
    DateTime startDate,
    DateTime endDate,
    string keyword) : IQuery<IList<CampaignsDetailDto>>;
