using MediatR;
using OnlineRivalMarket.Application.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.HomeGetTopIntelligenceRecord
{
    public class HomeGetTopIntelligenceRecordQueryHandler : IRequestHandler<HomeGetTopIntelligenceRecordQuery, HomeGetTopIntelligenceRecordQueryResponse>
    {
        private readonly IIntelligenceRecordService _service;

        public HomeGetTopIntelligenceRecordQueryHandler(IIntelligenceRecordService service)
        {
            _service = service;
        }
        public async Task<HomeGetTopIntelligenceRecordQueryResponse> Handle(HomeGetTopIntelligenceRecordQuery request, CancellationToken cancellationToken)
        {
            return new(await _service.HomeGetTopIntelligenceRecordAsync(request.CompanyId));
        }
    }
}
