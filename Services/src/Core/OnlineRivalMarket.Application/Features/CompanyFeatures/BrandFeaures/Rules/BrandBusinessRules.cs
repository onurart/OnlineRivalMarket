using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.BrandRepositories;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Rules;

public class BrandBusinessRules(IBrandQueryRepository brandQueryRepository)
{
    public Task IsbrandUnique(string name)
    {
        Brand? brand = brandQueryRepository.GetWhere(x => x.Name.ToUpper() == name.ToUpper(), false).FirstOrDefault();
        if (brand is not null)
        {
            throw new Exception("hata");
        }

        return Task.CompletedTask;
    }

    public async Task BrandShouldBeExists(string Id)
    {
        Brand? brand = await brandQueryRepository.GetById(Id, false);
        if (brand is null)
        {
            throw new Exception("hata");
        }
    }
    
}