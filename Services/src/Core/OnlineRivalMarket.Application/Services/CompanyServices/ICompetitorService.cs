namespace OnlineRivalMarket.Application.Services.CompanyServices;
public  interface ICompetitorService
{
    Task<Competitor> CreateCompetitorsAsync(CreateCompetitorsCommand requset, CancellationToken cancellationToken);
    Task<IList<Competitor>> GetAllCompetitorsAsync(string companyId);
}
