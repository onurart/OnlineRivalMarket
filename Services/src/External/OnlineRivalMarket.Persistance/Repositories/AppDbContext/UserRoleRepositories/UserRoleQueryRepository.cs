namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserRoleRepositories;
public sealed class UserRoleQueryRepository : AppQueryRepository<AppUserRole>, IUserRoleQueryRepository
{
    public UserRoleQueryRepository(Context.AppDbContext context) : base(context)
    {
    }
}
