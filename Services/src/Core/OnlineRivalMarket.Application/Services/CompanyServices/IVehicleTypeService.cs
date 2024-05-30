namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IVehicleTypeService
{
    Task<VehicleType> CreateVehicleTypeAsync(CreateVehicleTypeCommand requst, CancellationToken cancellationToken);
    Task<IList<VehicleType>> GetAllVehicleTypeAsync(string companyId);
}
