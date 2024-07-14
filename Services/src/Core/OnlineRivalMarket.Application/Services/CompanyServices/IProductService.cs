namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface IProductService
{
    Task<PaginationResult<ProductDto>> GetAllProductPaginationAsync(GetAllProductQuery request);
    Task<Product> CreateProductAsync(CreateProductCommand requst, CancellationToken cancellationToken);
    Task<IList<ProductSelectList>> GetSelectListAsync(string companyId);
    Task UpdateAsync(Product product, string companyId);
    Task<IList<ProductDto>> GetAllProduct(string companyId);
}