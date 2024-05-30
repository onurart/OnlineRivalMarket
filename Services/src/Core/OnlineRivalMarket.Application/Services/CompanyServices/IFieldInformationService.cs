using OnlineRivalMarket.Domain.Dtos.Campaing;

namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IFieldInformationService
{
    Task<IList<FieldInformationsesDto>> GetAllFieldInfoDtoFilterAsync(string companyId, List<string> competitorId, DateTime? startdate, DateTime? enddate, string keyword);
    Task<FieldInformation> CreateFieldInformationAsync(CreateFieldInformationCommand requset, CancellationToken cancellationToken);
    Task<IList<FieldInformationsesDto>> GetAllFieldInformationHomeAsync(FieldInformationHomeQuery companyId);
    Task<IList<FieldInformationsesDto>> GetAllFieldInformationDtoAsync(FieldInformationDtoQuery companyId);
    Task<IList<CompetitorIntelligenceRecordDto>> CompetitorIntelligenceRecord(string id, string companyId);
    Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id, string companyId);
    Task<IList<FieldInformation>> GetAllFieldInformationAsync(string companyId);


}
