namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IForeignCurrencyService
{
    Task<ForeignCurrency> CreateForeignCurrencyAsync(CreateForeignCurrencyCommand request, CancellationToken cancellationToken);
    Task<IList<ForeignCurrency>> GetAllForeignCurrencyAsync(string companyıd);
    Task<IList<ForeignCurrencyDto>> GetAllForeignCurrencyDtoAsync(string companyId);
}