using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.Queries.GetAllCategory;
public sealed record GetAllCategoryQuery(string? CompanyId, int PageNumber = 0, int PageSize = 10)  : IQuery<GetAllCategoryQueryResponse>;

