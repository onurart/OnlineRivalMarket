using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.CompanyRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.AppDbContext;
namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.CompanyRepositories
{
    public sealed class CompanyQueryRepository : AppQueryRepository<Company>, ICompanyQueryRepository
    {
        public CompanyQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
