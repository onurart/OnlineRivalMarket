using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.FieldInformationRepository;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;
namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.FieldInformationRepository
{
    public class FieldInformationCommandRepository : CompanyDbCommandRepository<FieldInformation>, IFieldInformationCommandRepository
    {
    }
}
