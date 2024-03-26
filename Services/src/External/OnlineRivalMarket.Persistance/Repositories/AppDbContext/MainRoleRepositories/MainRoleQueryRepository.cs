using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.Repositories.AppDbContext.MainRoleReporistories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Repositories.AppDbContext.MainRoleRepositories
{
    public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>, IMainRoleQueryRepository
    {
        public MainRoleQueryRepository(Context.AppDbContext context) : base(context)
        {
        }
    }
}
