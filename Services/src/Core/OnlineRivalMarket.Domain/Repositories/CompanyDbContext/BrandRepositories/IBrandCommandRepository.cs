using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Domain.Repositories.CompanyDbContext.BrandRepositories
{
    public interface IBrandCommandRepository : ICompanyDbCommandRepository<Brand>
    {
    }
}
