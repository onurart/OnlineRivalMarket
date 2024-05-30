namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IProductService
{
    Task<Product> CreateProductAsync(CreateProductCommand requst, CancellationToken cancellationToken);
    Task<PaginationResult<ProductDto>> GetAllProductPaginationAsync(GetAllProductQuery request);
    Task<IList<ProductSelectList>> GetSelectListAsync(string companyId);
    Task UpdateAsync(Product product, string companyId);
    Task<IList<ProductDto>> GetAllProduct(string companyId);
}