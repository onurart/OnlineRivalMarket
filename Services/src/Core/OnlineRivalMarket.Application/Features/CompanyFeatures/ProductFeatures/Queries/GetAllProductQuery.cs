namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries;
public sealed record GetAllProductQuery (string CompanyId, int PageNumber=1,int PageSize=10) : IQuery<GetAllProductQueryResponse>
{
}
