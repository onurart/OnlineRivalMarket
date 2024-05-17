using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationDto
{
    public sealed class FieldInformationDtoQueryHandle : IQueryHandler<FieldInformationDtoQuery, FieldInformationDtoQueryResponse>
    {
        private readonly IFieldInformationService _service;

        public FieldInformationDtoQueryHandle(IFieldInformationService service)
        {
            _service = service;
        }

        public async Task<FieldInformationDtoQueryResponse> Handle(FieldInformationDtoQuery request, CancellationToken cancellationToken)
        {
            return new(await _service.GetAllFieldInformationDtoAsync(request));
        }
    }
}
