using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationById;
public sealed class FieldInformationByIdQueryHandle : IQueryHandler<FieldInformationByIdQuery, FieldInformationByIdQueryResponse>
{
    private readonly IFieldInformationService _service;
    public FieldInformationByIdQueryHandle(IFieldInformationService service)
    {
        _service = service;
    }

    public async Task<FieldInformationByIdQueryResponse> Handle(FieldInformationByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetAllFieldInformationByIdAsync(request.CompanyId, request.id);
        return new FieldInformationByIdQueryResponse(result);
    }
}
