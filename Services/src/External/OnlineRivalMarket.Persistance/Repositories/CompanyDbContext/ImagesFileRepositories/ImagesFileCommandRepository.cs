using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ImagesFileRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.ImagesFileRepositories
{
    public sealed class ImagesFileCommandRepository :CompanyDbCommandRepository<ImagesFile>, IImagesFileCommandRepository
    {
    }
}
