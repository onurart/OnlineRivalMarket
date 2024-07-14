using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetFilteredIntelligenceRecordsAsync;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllDtoFilterIntelligenceRecord
{
    public sealed record GetAllDtoFilterIntelligenceRecordQuery(
        string companyId,
        List<string> competitorIds,
        List<string> productIds,
        List<string> brandIds,
        List<string> categoryIds,
        List<string> vehiclegroup,
        List<string> vehicleype,
        DateTime startDate,
        DateTime endDate,
        string keyword,
        int PageNumber = 1,
        int PageSize = 10) : IQuery<IntelligenceRecordFilterResponse>; // Dikkat: IQuery<IntelligenceRecordFilterResponse>
}
