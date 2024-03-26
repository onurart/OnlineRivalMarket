using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.BrandRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.BrandRepositories
{
    public class BrandQueryRepository : CompanyDbQueryRepository<Brand>, IBrandQueryRepository
    {
    }
}
