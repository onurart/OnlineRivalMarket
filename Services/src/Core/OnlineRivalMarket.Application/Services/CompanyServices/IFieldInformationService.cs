namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface  IFieldInformationService
{
    Task<FieldInformation> CreateFieldInformationAsync(CreateFieldInformationCommand requset, CancellationToken cancellationToken);
    Task<IList<FieldInformation>> GetAllFieldInformationAsync(string companyId);
    Task<IList<FieldInformationsesDto>> GetAllFieldInformationDtoAsync(FieldInformationDtoQuery companyId);
    Task<IList<FieldInformationsesDto>> GetAllFieldInformationHomeAsync(FieldInformationHomeQuery companyId);
    Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id,string companyId);
    Task<IList<FieldInformationsesDto>> GetAllFieldInfoDtoFilterAsync(string companyId, List<string> competitorId, DateTime? startdate, DateTime? enddate, string keyword);

}
