using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Dtos;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllDtoFilterIntelligenceRecord;
public record GetAllDtoFilterIntelligenceRecordQuery(
        string companyId,
    List<string> competitorIds,
    List<string> productIds,
    List<string> brandIds,
    List<string> categoryIds,
         List<string> vehiclegroup,
     List<string> vehicleype,
    DateTime startDate,
    DateTime endDate,
    string keyword) : IQuery<IList<IntelligenceRecordDto>>;