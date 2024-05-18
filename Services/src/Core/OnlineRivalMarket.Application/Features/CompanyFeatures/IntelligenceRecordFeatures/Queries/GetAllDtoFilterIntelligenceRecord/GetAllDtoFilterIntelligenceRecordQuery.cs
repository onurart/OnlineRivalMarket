using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Dtos;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllDtoFilterIntelligenceRecord;
public record GetAllDtoFilterIntelligenceRecordQuery(string companyId, List<string> competitorIds, List<string> brandIds, List<string> categoryIds, DateTime startDate, DateTime endDate):IQuery<IList<IntelligenceRecordDto>>;