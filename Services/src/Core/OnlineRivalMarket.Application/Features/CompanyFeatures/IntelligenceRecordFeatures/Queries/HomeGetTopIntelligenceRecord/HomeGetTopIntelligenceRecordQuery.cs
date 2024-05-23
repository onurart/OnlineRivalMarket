namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.HomeGetTopIntelligenceRecord
{
    public sealed record HomeGetTopIntelligenceRecordQuery(string CompanyId) : IQuery<HomeGetTopIntelligenceRecordQueryResponse> { }
}
