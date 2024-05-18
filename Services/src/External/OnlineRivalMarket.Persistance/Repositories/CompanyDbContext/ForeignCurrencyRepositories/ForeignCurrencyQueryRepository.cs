﻿using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ForeignCurrencyRepositories;
using OnlineRivalMarket.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.ForeignCurrencyRepositories
{
    public class ForeignCurrencyQueryRepository : CompanyDbQueryRepository<ForeignCurrency>, IForeignCurrencyQueryRepository
    {
    }
}