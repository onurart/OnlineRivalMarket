namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
public class MainRoleAndUserRelationshipQueryRepository : AppQueryRepository<MainRoleAndUserRelationship>, IMainRoleAndUserRelationshipQueryRepository
{
    public MainRoleAndUserRelationshipQueryRepository(Persistance.Context.AppDbContext context) : base(context) { }
}
