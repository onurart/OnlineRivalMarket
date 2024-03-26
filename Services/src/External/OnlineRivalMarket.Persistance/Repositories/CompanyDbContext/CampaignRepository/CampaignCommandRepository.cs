using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CampaignRepository;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CampaignRepository
{
    public sealed class CampaignCommandRepository : CompanyDbCommandRepository<Campaigns>, ICampaignCommandRepository
    {
    }
}
