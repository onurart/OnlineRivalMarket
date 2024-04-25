using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Domain.CompanyEntities;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
public sealed record GetAllCampaignQueryResponse(PaginationResult<Campaigns> Data);

