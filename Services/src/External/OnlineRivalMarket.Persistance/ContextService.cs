using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Domain;
using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Persistance.Context;
namespace OnlineRivalMarket.Persistance
{
    public class ContextService : IContextService
    {
        private readonly AppDbContext _appDbContext;

        public ContextService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DbContext CreateDbContextInstance(string companyId)
        {
            Company company = _appDbContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}
