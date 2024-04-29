using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetFilteredIntelligenceRecordsAsync;

public sealed record  IntelligenceRecordFilterQuery(string companyId, IList<string> competitorIds) :IQuery<IntelligenceRecordFilterResponse>;
