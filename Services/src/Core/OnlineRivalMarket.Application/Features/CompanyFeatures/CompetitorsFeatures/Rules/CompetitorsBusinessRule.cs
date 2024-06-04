using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CompetitorRepository;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Rules;
public class CompetitorsBusinessRule(ICompetitorQueryRepository competitorQueryRepository)
{
	public Task IsCompetitorUnique(string name)
	{
		Competitor? competitor = competitorQueryRepository.GetWhere(x => x.Name.ToUpper() == name.ToUpper(), false).FirstOrDefault();
		if (competitor is not null)
		{
			throw new Exception("Hata");
		}
		return Task.CompletedTask;
	}

	public async Task CompetitorsShoulBeExists(string Id)
	{
		Competitor competitor = await competitorQueryRepository.GetById(Id, false);
		if (competitor is null)
		{
			throw new Exception("Hata");
		}
	}
}
