using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbRepository<T> : IRepository<T> where T : Entity
    {
        void SetDbContextInstance(DbContext context);
    }
}
