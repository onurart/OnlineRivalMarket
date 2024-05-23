namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ILogService
    {
        Task AddAsync(Logs log, string companyId);
        Task<PaginationResult<LogDto>> GetAllByTableName(GetLogsByTableNameQuery request);
    }
}
