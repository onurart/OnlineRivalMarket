using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Dtos.Campaing;
using OnlineRivalMarket.Domain.Dtos.Campaing.GetAllDtoFilter;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoFilterCampaings;

public sealed record GetAllDtoFilterCampaingsQuery(
    string companyId,
    List<string> competitorIds,
    List<string> productIds,
    List<string> brandIds,
    List<string> categoryIds,
    DateTime startDate,
    DateTime endDate,
    DateTime CreateDate, DateTime EndCreateDate,
    string keyword) : IQuery<IList<GetAllDtoFilterDto>>;
