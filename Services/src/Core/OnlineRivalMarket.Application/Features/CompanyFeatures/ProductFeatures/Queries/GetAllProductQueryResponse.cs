using OnlineRivalMarket.Domain.CompanyEntities;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries
{
    public sealed record GetAllProductQueryResponse(IList<Product> Data);
}
