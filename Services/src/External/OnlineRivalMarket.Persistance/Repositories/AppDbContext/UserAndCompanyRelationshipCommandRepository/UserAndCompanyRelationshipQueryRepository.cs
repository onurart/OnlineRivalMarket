namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserAndCompanyRelationshipCommandRepository;
public class UserAndCompanyRelationshipQueryRepository : AppQueryRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipQueryRepository
{
    public UserAndCompanyRelationshipQueryRepository(Persistance.Context.AppDbContext context) : base(context) { }
}
