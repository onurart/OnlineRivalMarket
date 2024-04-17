using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.CompanyDbContext;
namespace OnlineRivalMarket.Domain.Repositories.CompanyDbContext.VehicleGroupRepository
{
    public interface IVehicleGroupCommandRepository : ICompanyDbCommandRepository<VehicleGroup>
    {
    }
}
