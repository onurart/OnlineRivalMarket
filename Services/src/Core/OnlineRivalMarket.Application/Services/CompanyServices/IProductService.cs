using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.Product;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(CreateProductCommand requst, CancellationToken cancellationToken);
        Task<PaginationResult<ProductDto>> GetAllAsync(GetAllProductQuery request);
        Task UpdateAsync(Product product, string companyId);
    }
}
