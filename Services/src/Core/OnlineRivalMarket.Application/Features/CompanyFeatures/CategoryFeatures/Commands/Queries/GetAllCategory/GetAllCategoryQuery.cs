namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.Queries.GetAllCategory;
public sealed record GetAllCategoryQuery(string? CompanyId)  : IQuery<GetAllCategoryQueryResponse>;

