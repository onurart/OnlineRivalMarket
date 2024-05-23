namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.MainRoleRepositories;
public sealed class MainRoleCommandRepository : AppCommandRepository<MainRole>, IMainRoleCommandRepository
{
    public MainRoleCommandRepository(Context.AppDbContext context) : base(context) { }
}
