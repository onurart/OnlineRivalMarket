using OnlineRivalMarket.Domain.AppEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Repositories.AppDbContext.MainRoleReporistories
{
    public interface IMainRoleCommandRepository :  ICommandGenericRepository<MainRole>
    {
    }
}
