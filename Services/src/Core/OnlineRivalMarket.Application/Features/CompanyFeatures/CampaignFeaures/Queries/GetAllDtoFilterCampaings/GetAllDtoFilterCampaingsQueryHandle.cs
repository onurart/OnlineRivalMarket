using OnlineRivalMarket.Domain.Dtos.Campaing;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoFilterCampaings;
public sealed class GetAllDtoFilterCampaingsQueryHandle(ICampaignService _service) : IQueryHandler<GetAllDtoFilterCampaingsQuery, IList<CampaignsDetailDto>>
{
    public async Task<IList<CampaignsDetailDto>> Handle(GetAllDtoFilterCampaingsQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllDtoFilterAsync(
      request.companyId,
      request.competitorIds,
      request.productIds,
      request.brandIds,
      request.categoryIds,
      request.startDate,
      request.endDate,
      request.CreateDate,
      request.EndCreateDate,
      request.keyword);

        return result;
    }
}
