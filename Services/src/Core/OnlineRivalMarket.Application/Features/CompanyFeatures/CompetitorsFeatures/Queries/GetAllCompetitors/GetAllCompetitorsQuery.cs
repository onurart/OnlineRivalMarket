using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Queries.GetAllCompetitors;
public sealed record GetAllCompetitorsQuery(string CompanyId) : IQuery<GetAllCompetitorsQueryResponse>;