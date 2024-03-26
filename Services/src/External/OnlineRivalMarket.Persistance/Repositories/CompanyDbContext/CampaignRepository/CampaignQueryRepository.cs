using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CampaignRepository;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CampaignRepository
{
    public sealed class CampaignQueryRepository : CompanyDbQueryRepository<Campaigns>, ICampaignQueryRepository
    {
    }
}
