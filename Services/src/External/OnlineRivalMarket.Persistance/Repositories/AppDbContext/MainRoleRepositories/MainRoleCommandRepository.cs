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
    public sealed class MainRoleCommandRepository : AppCommandRepository<MainRole>, IMainRoleCommandRepository
    {
        public MainRoleCommandRepository(Context.AppDbContext context) : base(context) { }
    }
}
