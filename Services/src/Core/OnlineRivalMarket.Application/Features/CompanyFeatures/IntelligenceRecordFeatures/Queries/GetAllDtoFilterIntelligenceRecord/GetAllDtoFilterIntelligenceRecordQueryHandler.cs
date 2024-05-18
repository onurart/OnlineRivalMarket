using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.Dtos;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllDtoFilterIntelligenceRecord;

public sealed class GetAllDtoFilterIntelligenceRecordQueryHandler(IIntelligenceRecordService _service):IQueryHandler<GetAllDtoFilterIntelligenceRecordQuery,IList<IntelligenceRecordDto>>
{
    public async Task<IList<IntelligenceRecordDto>> Handle(GetAllDtoFilterIntelligenceRecordQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllDtoFilterAsync(request.companyId,request.competitorIds,request.brandIds,request.categoryIds,request.startDate,request.endDate);
        return result; //  new(result);
    }
}