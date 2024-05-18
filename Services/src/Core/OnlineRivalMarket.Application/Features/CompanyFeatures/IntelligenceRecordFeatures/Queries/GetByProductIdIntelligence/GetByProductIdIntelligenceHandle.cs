using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetByProductIdIntelligence
{
    public class GetByProductIdIntelligenceHandle : IQueryHandler<GetByProductIdIntelligenceQuery, GetByProductIdIntelligenceResponse>
    {
        private readonly IIntelligenceRecordService _service;

        public GetByProductIdIntelligenceHandle(IIntelligenceRecordService service)
        {
            _service = service;
        }
        public async Task<GetByProductIdIntelligenceResponse> Handle(GetByProductIdIntelligenceQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetByProductIdIntelligenceRecordsAsync(request.id, request.CompanyId);
            return new GetByProductIdIntelligenceResponse(result);

        }
    }
}
