using OnlineRivalMarket.Domain.Dtos.Campaing.HomeTopDto;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;
public sealed record GetAllCampaingDtoResponse(PaginationResult<HomeTopCampaignDto> Data);

