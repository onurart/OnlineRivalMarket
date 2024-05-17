using OnlineRivalMarket.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.CompanyEntities
{
    public  class ForeignCurrency  : Entity
    {
        public string? CurrencyName { get; set; }
    }
}
