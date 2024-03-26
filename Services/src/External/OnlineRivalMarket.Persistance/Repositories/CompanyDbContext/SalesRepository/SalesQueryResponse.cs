using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.SalesRepository;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;
namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.SalesRepository
{
    public sealed class SalesQueryResponse : CompanyDbQueryRepository<Sales>, ISalesQueryRepository
    {
    }
}
