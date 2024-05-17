using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.Product;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetSelectListAsync;
public sealed record GetSelectListAsyncQueryResponse(IList<ProductSelectList> Data);

