namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IIntelligenceRecordService
{
    Task<PaginationResult<IntelligenceRecordDto>> GetAllIIntelligenceDtoFilterAsync(string companyId,
        List<string> competitorIds,
        List<string> vehiclegroup,
        List<string> categoryIds,
        List<string> productIds,
        List<string> vehicleype,
        List<string> brandIds,
        DateTime startDate,
        DateTime endDate,
        string keyword,
        int pageNumber,
        int pageSize);
    Task<IntelligenceRecord> CreateIntelligenceRecordAsync(CreateIntelligenceRecordCommand requset, CancellationToken cancellationToken);
    Task<IList<IntelligenceByIdDto>> GetByProductIdIntelligenceRecordsAsync(string id, string companyId);
    Task<IList<IntelligenceByIdDto>> GetByIdIntelligenceRecordsAsync(string id, string companyId);
    Task<IList<IntelligenceRecordDto>> HomeGetTopIntelligenceRecordAsync(string companyId);
    //Task<IList<IntelligenceRecordDto>> GetAllIIntelligenceDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, List<string> vehiclegroup, List<string> vehicleype, DateTime startDate, DateTime endDate, string keyword);
    Task<IList<IntelligenceRecordDto>> GetAllDtoAsync(string companyId);
}