using OnlineRivalMarket.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Services.AppServices
{
    public interface IMainRoleService
    {
        Task<MainRole> GetByTitleAndCompanyId(string title, CancellationToken cancellationToken);
        Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
        Task CreateRangeAsync(List<MainRole> newMainRoles, CancellationToken cancellationToken);
        IQueryable<MainRole> GetAll();
        Task RemoveByIdAsync(string id);
        Task<MainRole> GetByIdAsync(string id);
        Task UpdateAsync(MainRole mainRole);
    }
}
