using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserAndCompanyRelationshipCommandRepository
{
    public class UserAndCompanyRelationshipCommandRepository : AppCommandRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipCommandRepository
    {
        public UserAndCompanyRelationshipCommandRepository(Persistance.Context.AppDbContext context) : base(context) { }
    }
}
