namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.MainRoleRepositories;
public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>, IMainRoleQueryRepository
{
    public MainRoleQueryRepository(Context.AppDbContext context) : base(context)
    {
    }
}
