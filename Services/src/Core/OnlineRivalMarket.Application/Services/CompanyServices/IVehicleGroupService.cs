
namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IVehicleGroupService
    {
        Task<VehicleGroup> CreateVehicleGroupAsync(CreateVehicleGroupCommand request, CancellationToken cancellationToken);
        Task<IList<VehicleGroup>> GetAllVehicleGroupAsync(string CompanyId);
    }
}
