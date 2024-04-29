using OnlineRivalMarket.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllIntelligenceRecord;
public sealed class GetAllIntelligenceRecordQueryHandler : IQueryHandler<GetAllIntelligenceRecordQuery, GetAllIntelligenceRecordQueryResponse>
{
    private readonly IIntelligenceRecordService _service;
public GetAllIntelligenceRecordQueryHandler(IIntelligenceRecordService service)
    {
        _service = service;
    }

    public Task<GetAllIntelligenceRecordQueryResponse> Handle(GetAllIntelligenceRecordQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //public async Task<GetAllIntelligenceRecordQueryResponse> Handle(GetAllIntelligenceRecordQuery request, CancellationToken cancellationToken)
    //{
    //    return new(await _service.GetAllIntelligenceRecordAsync(request.CompanyId));
    //}
}
