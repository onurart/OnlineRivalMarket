using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetByIdIntelligenceRecord;
public sealed record GetByIdIntelligenceRecordQueryHandler : IQueryHandler<GetByIdIntelligenceRecordQuery, GetByIdIntelligenceRecordQueryResponse>
{
    private readonly IIntelligenceRecordService _service;

    public GetByIdIntelligenceRecordQueryHandler(IIntelligenceRecordService service)
    {
        _service = service;
    }

    public async Task<GetByIdIntelligenceRecordQueryResponse> Handle(GetByIdIntelligenceRecordQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetByIdIntelligenceRecordsAsync(request.id, request.CompanyId);
        return new GetByIdIntelligenceRecordQueryResponse(result);
    }
}
