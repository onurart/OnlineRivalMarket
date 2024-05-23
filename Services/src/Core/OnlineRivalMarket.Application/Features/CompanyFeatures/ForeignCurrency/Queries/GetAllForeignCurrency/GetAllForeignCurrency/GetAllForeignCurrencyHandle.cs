namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Queries.GetAllForeignCurrency.GetAllForeignCurrency;
public sealed class GetAllForeignCurrencyHandle : IQueryHandler<GetAllForeignCurrencyQuery, GetAllForeignCurrencyResponse>
{
    private readonly IForeignCurrencyService _service;
    public GetAllForeignCurrencyHandle(IForeignCurrencyService service)
    {
        _service = service;
    }
    public async Task<GetAllForeignCurrencyResponse> Handle(GetAllForeignCurrencyQuery request, CancellationToken cancellationToken)
    {
        return new(await _service.GetAllForeignCurrencyAsync(request.CompanyId));
    }
}
