using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetFilteredIntelligenceRecordsAsync;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllDtoFilterIntelligenceRecord;

public sealed class GetAllDtoFilterIntelligenceRecordQueryHandler : IQueryHandler<GetAllDtoFilterIntelligenceRecordQuery, IntelligenceRecordFilterResponse>
{
    private readonly IIntelligenceRecordService _service;

    public GetAllDtoFilterIntelligenceRecordQueryHandler(IIntelligenceRecordService service)
    {
        _service = service;
    }

    public async Task<IntelligenceRecordFilterResponse> Handle(GetAllDtoFilterIntelligenceRecordQuery request, CancellationToken cancellationToken)
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
      request.keyword, request.PageNumber, request.PageSize);
        return new IntelligenceRecordFilterResponse(result);
    }
}