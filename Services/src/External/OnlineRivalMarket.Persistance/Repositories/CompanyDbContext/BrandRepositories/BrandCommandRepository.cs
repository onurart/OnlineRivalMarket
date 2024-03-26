using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.BrandRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.BrandRepositories
{
    public class BrandCommandRepository : CompanyDbCommandRepository<Brand>, IBrandCommandRepository
    {
    }
}
