using MediatR;
using OnlineRivalMarket.Application.Services.CompanyServices;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.IntelligenceRecordDtos
{
    public sealed class IntelligenceRecordDtoQueryHandler : IRequestHandler<IntelligenceRecordDtoQuery, IntelligenceRecordDtoQueryResponse>
    {
        private readonly IIntelligenceRecordService _service;

        public IntelligenceRecordDtoQueryHandler(IIntelligenceRecordService service)
        {
            _service = service;
        }
        public async Task<IntelligenceRecordDtoQueryResponse> Handle(IntelligenceRecordDtoQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllDtoAsync(request.CompanyId);
            return new IntelligenceRecordDtoQueryResponse(result);
        }
    }
}
