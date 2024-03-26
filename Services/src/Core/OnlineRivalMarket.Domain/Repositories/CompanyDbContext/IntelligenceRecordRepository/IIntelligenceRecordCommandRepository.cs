using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Repositories.CompanyDbContext.IntelligenceRecordRepository
{
    public interface  IIntelligenceRecordCommandRepository : ICompanyDbCommandRepository<IntelligenceRecord>
    {
    }
}
