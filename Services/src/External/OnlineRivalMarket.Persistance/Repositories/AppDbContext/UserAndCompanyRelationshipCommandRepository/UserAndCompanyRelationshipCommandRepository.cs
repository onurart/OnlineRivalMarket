namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserAndCompanyRelationshipCommandRepository;
public class UserAndCompanyRelationshipCommandRepository : AppCommandRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipCommandRepository
{
    public UserAndCompanyRelationshipCommandRepository(Persistance.Context.AppDbContext context) : base(context) { }
}
