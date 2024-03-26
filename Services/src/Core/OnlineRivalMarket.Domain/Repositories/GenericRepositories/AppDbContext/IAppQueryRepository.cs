using OnlineRivalMarket.Domain.Abstractions;
namespace OnlineRivalMarket.Domain.Repositories.GenericRepositories.AppDbContext
{
    public interface IAppQueryRepository<T> : IQueryGenericRepository<T>, IRepository<T> where T : Entity
    {
    }
}
