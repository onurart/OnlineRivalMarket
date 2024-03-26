using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllIntelligenceRecord;
    public sealed record GetAllIntelligenceRecordQueryResponse(IList<IntelligenceRecord> Data);