namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.MainRoleAndUserRelationshipRepositories;
public class MainRoleAndUserRelationshipCommandRepository : AppCommandRepository<MainRoleAndUserRelationship>, IMainRoleAndUserRelationshipCommandRepository
{
    public MainRoleAndUserRelationshipCommandRepository(Persistance.Context.AppDbContext context) : base(context) { }
}
