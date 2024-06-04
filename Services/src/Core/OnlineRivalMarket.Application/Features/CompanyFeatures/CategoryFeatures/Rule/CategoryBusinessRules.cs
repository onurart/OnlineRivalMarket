using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CategoryRepository;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Rule;
public class CategoryBusinessRules(ICategoryQueryRepository categoryQueryRepository)
{
	public Task IsCategoryUnique(string name)
	{
		Category? category = categoryQueryRepository.GetWhere(x => x.Name.ToUpper() == name.ToUpper(), false).FirstOrDefault();
		if (category == null)
		{
			throw new Exception("Hata");
		}
		return Task.CompletedTask;
	}
	public async Task CategoryShouleBeExists(string Id)
	{
		Category category = await categoryQueryRepository.GetById(Id, false);
		if (category == null)
		{
			throw new Exception("hata");
		}
	}
}