using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CampaingImagesFileRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.CampaingCommandRepositories
{
    public sealed class CampaingFileCommandRepository : CompanyDbCommandRepository<CampaingImagesFile> , ICampaingFileCommandRepository
    {
    }
}
