using OnlineRivalMarket.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.CompanyEntities
{
    public sealed class Logs : Entity
    {
        public string? UserId { get; set; }
        public string? TableName { get; set; }
        public string? Data { get; set; }
        public string? Progress { get; set; }
    }
    }
