namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.CompanyRepositories;
public sealed class CompanyCommandRepository : AppCommandRepository<Company>, ICompanyCommandRepository
{
    public CompanyCommandRepository(Context.AppDbContext context) : base(context)
    {
    }
}
