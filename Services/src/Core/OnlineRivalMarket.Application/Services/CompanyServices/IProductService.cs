using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(CreateProductCommand requst, CancellationToken cancellationToken);
        Task<IList<Product>> GetAllAsync(string companyId);
        Task UpdateAsync(Product product, string companyId);
    }
}
