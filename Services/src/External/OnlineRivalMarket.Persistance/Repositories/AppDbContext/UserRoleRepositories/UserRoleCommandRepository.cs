namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserRoleRepositories;
public sealed class UserRoleCommandRepository : AppCommandRepository<AppUserRole>, IUserRoleCommandRepository
{
    public UserRoleCommandRepository(Context.AppDbContext context) : base(context)
    {
    }
}
