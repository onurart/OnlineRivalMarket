using OnlineRivalMarket.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Queries.GetAllForeignCurrency.GetAllForeignCurrency
{
    public sealed record GetAllForeignCurrencyResponse(IList<OnlineRivalMarket.Domain.CompanyEntities.ForeignCurrency> Data)
    { 
    }
}
