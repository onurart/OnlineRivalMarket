using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.IntelligenceDto;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IIntelligenceRecordService
    {
        Task<IntelligenceRecord> CreateIntelligenceRecordAsync(CreateIntelligenceRecordCommand requset, CancellationToken cancellationToken);
        //Task<IList<IntelligenceRecord>> GetAllIntelligenceRecordAsync(string companyId);
        Task<IList<IntelligenceRecordDto>> GetAllDtoAsync(string companyId);
        Task<IList<IntelligenceRecordDto>> GetFilteredIntelligenceRecordsAsync(string companyId, IList<string> competitorIds);
        Task<IList<IntelligenceRecordDto>> HomeGetTopIntelligenceRecordAsync(string companyId);
        Task<IList<IntelligenceByIdDto>> GetByIdIntelligenceRecordsAsync(string id, string companyId);
        Task<IList<IntelligenceByIdDto>> GetByProductIdIntelligenceRecordsAsync(string id, string companyId);
    }
}