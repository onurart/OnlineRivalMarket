
namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IIntelligenceRecordService
    {
        Task<IntelligenceRecord> CreateIntelligenceRecordAsync(CreateIntelligenceRecordCommand requset, CancellationToken cancellationToken);
        Task<IList<IntelligenceRecordDto>> GetAllDtoAsync(string companyId);
        Task<IList<IntelligenceRecordDto>> GetAllIIntelligenceDtoFilterAsync(string companyId,List<string> competitorIds,List<string> productIds,List<string> brandIds,List<string> categoryIds,List<string> vehiclegroup,List<string> vehicleype,DateTime startDate,DateTime endDate,string keyword);
        Task<IList<IntelligenceRecordDto>> GetFilteredIntelligenceRecordsAsync(string companyId, IList<string> competitorIds);
        Task<IList<IntelligenceRecordDto>> HomeGetTopIntelligenceRecordAsync(string companyId);
        Task<IList<IntelligenceByIdDto>> GetByIdIntelligenceRecordsAsync(string id, string companyId);
        Task<IList<IntelligenceByIdDto>> GetByProductIdIntelligenceRecordsAsync(string id, string companyId);
    }
}