using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.Queries.GetAllCategory;
public sealed record GetAllCategoryQueryResponse(PaginationResult<Category> Data);

