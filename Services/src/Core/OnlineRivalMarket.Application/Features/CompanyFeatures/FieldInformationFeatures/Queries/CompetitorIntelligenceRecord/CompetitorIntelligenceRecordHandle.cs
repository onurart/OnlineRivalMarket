namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.CompetitorIntelligenceRecord;
public sealed class CompetitorIntelligenceRecordHandle : IQueryHandler<CompetitorIntelligenceRecordQuery, CompetitorIntelligenceRecordResponse>
{
    private readonly IFieldInformationService _fieldInformationService;
    public CompetitorIntelligenceRecordHandle(IFieldInformationService fieldInformationService)
    { _fieldInformationService = fieldInformationService; }
    public async Task<CompetitorIntelligenceRecordResponse> Handle(CompetitorIntelligenceRecordQuery request, CancellationToken cancellationToken)
    {
        var competitor = await _fieldInformationService.CompetitorIntelligenceRecord(request.id, request.CompanyId);
        return new CompetitorIntelligenceRecordResponse(competitor);
    }
}
