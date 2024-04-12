using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Queries.GetAllCompetitors;
public sealed record GetAllCompetitorsQueryResponse(IList<Competitor> Data);