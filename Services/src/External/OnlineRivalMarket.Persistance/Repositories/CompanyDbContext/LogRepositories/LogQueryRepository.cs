using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.LogRepositories;
using OnlineRivalMarket.Persistance.Configurations;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.LogRepositories
{
    public class LogQueryRepository : CompanyDbQueryRepository<Logs>, ILogQueryRepository
    {
    }
}
