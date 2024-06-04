using OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Rules;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors;
public class CreateCompetitorsCommandHandle : ICommandHandler<CreateCompetitorsCommand, CreateCompetitorsCommandResponse>
{
    private readonly IApiService _apiService;
    private readonly ILogService _servicelog;
    private readonly ICompetitorService _competitorService;
    private readonly CompetitorsBusinessRule _competitorsBusinessRule;
	public CreateCompetitorsCommandHandle(IApiService apiService, ILogService servicelog, ICompetitorService competitorService, CompetitorsBusinessRule competitorsBusinessRule = null)
	{
		_apiService = apiService;
		_servicelog = servicelog;
		_competitorService = competitorService;
		_competitorsBusinessRule = competitorsBusinessRule;
	}

	public async Task<CreateCompetitorsCommandResponse> Handle(CreateCompetitorsCommand request, CancellationToken cancellationToken)
    {
        await _competitorsBusinessRule.IsCompetitorUnique(request.Name);
        Competitor createBrand = await _competitorService.CreateCompetitorsAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Logs log = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(Brand),
            Progress = "Create",
            UserId = userId,
            Data = JsonConvert.SerializeObject(createBrand)
        };
        await _servicelog.AddAsync(log, request.companyId);
        return new();
    }
}
