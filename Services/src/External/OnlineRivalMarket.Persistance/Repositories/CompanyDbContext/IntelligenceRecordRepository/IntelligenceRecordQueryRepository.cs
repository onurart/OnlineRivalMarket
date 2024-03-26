using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.IntelligenceRecordRepository;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.IntelligenceRecordRepository
{
    public sealed class IntelligenceRecordQueryRepository : CompanyDbQueryRepository<IntelligenceRecord>, IIntelligenceRecordQueryRepository
    {
    }
}
