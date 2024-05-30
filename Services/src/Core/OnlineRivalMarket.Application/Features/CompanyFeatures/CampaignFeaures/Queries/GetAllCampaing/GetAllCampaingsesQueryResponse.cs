using OnlineRivalMarket.Domain.Dtos.Campaing.GetAllCampaing;
using OnlineRivalMarket.Domain.Dtos.Campaing.HomeTopDto;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllCampaing;
public sealed  record class GetAllCampaingsesQueryResponse(IList<GetAllCampaingDto> Data);
