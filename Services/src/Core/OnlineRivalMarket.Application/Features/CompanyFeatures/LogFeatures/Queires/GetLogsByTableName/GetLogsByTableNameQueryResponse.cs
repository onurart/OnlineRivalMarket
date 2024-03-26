using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Domain.Dtos;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
public sealed record GetLogsByTableNameQueryResponse(PaginationResult<LogDto> Data);
