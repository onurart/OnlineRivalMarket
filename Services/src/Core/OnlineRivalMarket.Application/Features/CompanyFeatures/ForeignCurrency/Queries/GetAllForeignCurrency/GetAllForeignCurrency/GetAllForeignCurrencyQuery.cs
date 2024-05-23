namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Queries.GetAllForeignCurrency.GetAllForeignCurrency;
public sealed record GetAllForeignCurrencyQuery(string CompanyId) : IQuery<GetAllForeignCurrencyResponse>
{
}
