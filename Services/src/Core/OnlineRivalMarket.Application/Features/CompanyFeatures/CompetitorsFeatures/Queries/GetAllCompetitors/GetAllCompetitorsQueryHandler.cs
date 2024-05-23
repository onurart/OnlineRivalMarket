namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Queries.GetAllCompetitors;
public class GetAllCompetitorsQueryHandler : IQueryHandler<GetAllCompetitorsQuery, GetAllCompetitorsQueryResponse>
{
    private readonly ICompetitorService _competitorService;
    public GetAllCompetitorsQueryHandler(ICompetitorService competitorService)
    {
        _competitorService = competitorService;
    }
    public async Task<GetAllCompetitorsQueryResponse> Handle(GetAllCompetitorsQuery request, CancellationToken cancellationToken)
    {
        return new(await _competitorService.GetAllCompetitorsAsync(request.CompanyId));
    }
}
