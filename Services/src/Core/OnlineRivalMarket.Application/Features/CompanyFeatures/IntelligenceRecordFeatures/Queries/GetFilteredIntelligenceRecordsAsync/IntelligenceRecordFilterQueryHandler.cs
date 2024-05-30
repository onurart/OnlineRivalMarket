namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetFilteredIntelligenceRecordsAsync;
public sealed class IntelligenceRecordFilterQueryHandler : IRequestHandler<IntelligenceRecordFilterQuery, IntelligenceRecordFilterResponse>
{
    private readonly IIntelligenceRecordService _service;
    public IntelligenceRecordFilterQueryHandler(IIntelligenceRecordService service)
    {
        _service = service;
    }
    public async Task<IntelligenceRecordFilterResponse> Handle(IntelligenceRecordFilterQuery request, CancellationToken cancellationToken)
    {
        //var result = await _service.GetFilteredIntelligenceRecordsAsync(request.companyId, request.competitorIds);
        //return new IntelligenceRecordFilterResponse(result);
        return new(null);

    }

}
