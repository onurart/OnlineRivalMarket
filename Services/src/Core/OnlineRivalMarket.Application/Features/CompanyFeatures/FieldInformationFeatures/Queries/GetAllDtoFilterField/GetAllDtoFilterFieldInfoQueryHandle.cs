using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoFilterCampaings;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.Dtos.FieldInformationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.GetAllDtoFilterField
{
    public sealed class GetAllDtoFilterFieldInfoQueryHandle(IFieldInformationService _service) : IQueryHandler<GetAllDtoFilterFieldInfoQuery, IList<FieldInformationsesDto>>
    {
        public async Task<IList<FieldInformationsesDto>> Handle(GetAllDtoFilterFieldInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllFieldInfoDtoFilterAsync(request.companyId, request.competitorIds, request.startDate, request.endDate,request.keyword);
            return result; //  new(result);
        }
    }
}
