using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllDtoFilterIntelligenceRecord;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoFilterCampaings
{
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
          request.keyword);

            return result;
        }
    }
}
