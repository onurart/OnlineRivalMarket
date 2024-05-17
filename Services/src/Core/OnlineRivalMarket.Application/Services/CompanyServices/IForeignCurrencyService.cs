using OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Commamds;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.ForeignCurrency;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IForeignCurrencyService
    {
        Task<ForeignCurrency> CreateForeignCurrencyAsync(CreateForeignCurrencyCommand request, CancellationToken cancellationToken);
        Task<IList<ForeignCurrency>> GetAllForeignCurrencyAsync(string companyıd);
        Task<IList<ForeignCurrencyDto>> GetAllForeignCurrencyDtoAsync(string companyId);
    }
}
