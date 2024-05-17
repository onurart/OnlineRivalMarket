using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CFImagesFileRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CFFileRepositories
{
    public  class  CFFileCommandRepositories : CompanyDbCommandRepository<FieldInformationImagesFile>, ICFFileCommandRepository
    {
    }
}
