using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.Product;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries
{
    public sealed record GetAllProductQueryResponse(PaginationResult<ProductDto> Data);
}
