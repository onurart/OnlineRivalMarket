using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Queries.GetAllForeignCurrency.GetAllForeignCurrencyDtoAsync;
public sealed class GetAllForeignCurrencyDtoQueryHandle : IQueryHandler<GetAllForeignCurrencyDtoQuery, GetAllForeignCurrencyDtoQueryResponse>
{
    private readonly IForeignCurrencyService _service;

    public GetAllForeignCurrencyDtoQueryHandle(IForeignCurrencyService service)
    {
        _service = service;
    }
    public async Task<GetAllForeignCurrencyDtoQueryResponse> Handle(GetAllForeignCurrencyDtoQuery request, CancellationToken cancellationToken)
    {
        return new(await _service.GetAllForeignCurrencyDtoAsync(request.CompanyId));
    }
}
