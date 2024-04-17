using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.VehicleTypeRepository;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;
namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.VehicleTypeRepository
{
    public sealed class VehicleTypeQueryRepository : CompanyDbQueryRepository<VehicleType>, IVehicleTypeQuertRepository
    {
    }
}
