using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.HomeGetTopIntelligenceRecord
{
    public sealed record HomeGetTopIntelligenceRecordQuery(string CompanyId) : IQuery<HomeGetTopIntelligenceRecordQueryResponse>
    {
    }
}
