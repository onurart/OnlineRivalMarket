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
}
