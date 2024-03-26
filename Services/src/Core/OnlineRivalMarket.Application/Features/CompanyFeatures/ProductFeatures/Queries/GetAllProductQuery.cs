using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries
{
    public sealed record GetAllProductQuery (string CompanyId) : IQuery<GetAllProductQueryResponse>
    {
    }
}
