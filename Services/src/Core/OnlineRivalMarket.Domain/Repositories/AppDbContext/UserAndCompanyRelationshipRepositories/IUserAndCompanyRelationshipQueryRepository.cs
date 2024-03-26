using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Repositories.AppDbContext.UserAndCompanyRelationshipRepositories
{
    public interface IUserAndCompanyRelationshipQueryRepository : IAppQueryRepository<UserAndCompanyRelationship>
    {
    }
}
