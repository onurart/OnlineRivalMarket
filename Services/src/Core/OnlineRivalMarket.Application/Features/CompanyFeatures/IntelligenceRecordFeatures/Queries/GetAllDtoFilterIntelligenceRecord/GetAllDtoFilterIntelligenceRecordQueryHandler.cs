namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllDtoFilterIntelligenceRecord;

public sealed class GetAllDtoFilterIntelligenceRecordQueryHandler(IIntelligenceRecordService _service) : IQueryHandler<GetAllDtoFilterIntelligenceRecordQuery, IList<IntelligenceRecordDto>>
{
    public async Task<IList<IntelligenceRecordDto>> Handle(GetAllDtoFilterIntelligenceRecordQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllIIntelligenceDtoFilterAsync
            (
          request.companyId,
          request.competitorIds,
          request.productIds,
          request.brandIds,
          request.categoryIds,
          request.vehiclegroup,
          request.vehicleype,
          request.startDate,
          request.endDate,
          request.keyword);
        return result;
    }
}