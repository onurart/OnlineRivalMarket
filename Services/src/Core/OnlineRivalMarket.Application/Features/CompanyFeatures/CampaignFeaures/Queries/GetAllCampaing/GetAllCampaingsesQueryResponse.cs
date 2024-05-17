using OnlineRivalMarket.Domain.Dtos.HomeTopDto;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllCampaing;
public sealed  record class GetAllCampaingsesQueryResponse(IList<HomeTopCampaignDto> Data);
