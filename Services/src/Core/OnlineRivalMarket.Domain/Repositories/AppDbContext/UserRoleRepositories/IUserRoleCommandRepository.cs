using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Repositories.AppDbContext.UserRoleRepositories
{
    public interface IUserRoleCommandRepository : IAppCommandRepository<AppUserRole>
    {
    }
}
