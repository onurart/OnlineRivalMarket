using OnlineRivalMarket.Domain.AppEntities.Identity;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.UserRoleRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.UserRoleRepositories
{
    public sealed class UserRoleQueryRepository : AppQueryRepository<AppUserRole>, IUserRoleQueryRepository
    {
        public UserRoleQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
