using OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors;
using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public  interface ICompetitorService
    {
        Task<Competitorses> CreateCompetitorsAsync(CreateCompetitorsCommand requset, CancellationToken cancellationToken);
        Task<IList<Competitorses>> GetAllCompetitorsAsync(string companyId);
    }
}
