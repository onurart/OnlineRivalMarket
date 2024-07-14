using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.VehicleTypeRepository;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Rule;
public  class VehicleTypeBussinesRule(IVehicleTypeQuertRepository vehicleTypeQuertRepository)
{
	public Task VehicleTypeÜ(string name)
	{
		VehicleType? vehicleType = vehicleTypeQuertRepository.GetWhere(x => x.Name.ToUpper() == name.ToUpper(), false).FirstOrDefault();
		if (vehicleType is not null )
		{
			throw new Exception("Hata");
		}
		return Task.CompletedTask;
	}

	public async Task VehicleTypeShoulBeExists(string Id)
	{
		VehicleType vehicleType = await vehicleTypeQuertRepository.GetById(Id,false);
		if (vehicleType is not null)
		{
			throw new Exception("Hata");
		}
	}
}
