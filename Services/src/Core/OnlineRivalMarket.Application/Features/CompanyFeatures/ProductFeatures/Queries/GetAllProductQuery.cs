using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries
{
    public sealed record GetAllProductQuery (string CompanyId, int PageNumber = 0, int PageSize = 10) : IQuery<GetAllProductQueryResponse>
    {
    }
}
