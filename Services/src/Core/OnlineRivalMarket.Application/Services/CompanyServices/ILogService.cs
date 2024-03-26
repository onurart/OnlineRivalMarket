using OnlineRivalMarket.Application.Features.CompanyFeatures.LogFeatures.Queires.GetLogsByTableName;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ILogService
    {
        Task AddAsync(Logs log, string companyId);
        Task<PaginationResult<LogDto>> GetAllByTableName(GetLogsByTableNameQuery request);
    }
}
