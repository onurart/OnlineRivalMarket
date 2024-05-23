namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.CompanyRepositories;
public sealed class CompanyQueryRepository : AppQueryRepository<Company>, ICompanyQueryRepository
{
    public CompanyQueryRepository(Context.AppDbContext context) : base(context)
    {
    }
}
