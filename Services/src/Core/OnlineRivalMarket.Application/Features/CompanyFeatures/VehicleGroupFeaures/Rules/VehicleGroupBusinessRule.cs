using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.VehicleGroupRepository;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Rules;
public class VehicleGroupBusinessRule(IVehicleGroupQueryRepository vehicleGroupQueryRepository)
{
	public Task IsVehicleGroupUnique(string name)
	{
		VehicleGroup? vehicleGroup = vehicleGroupQueryRepository.GetWhere(x => x.Name.ToUpper() == name.ToUpper(),false).FirstOrDefault();
		if (vehicleGroup is not null)
		{
			throw new Exception("Hata");
		}
		return Task.CompletedTask;
	}
	public async Task IsVehicleGroupshoulBeExists(string Id)
	{
		VehicleGroup vehicleGroup= await vehicleGroupQueryRepository.GetById(Id,false);
		if (vehicleGroup is not null)
		{
			throw new Exception("Hata");
		}
	}
}
