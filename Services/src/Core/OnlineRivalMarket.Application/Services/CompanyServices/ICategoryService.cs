namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface ICategoryService
{
    Task<Category> CreateCategoryAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
    Task<IList<Category>> GetAllCategoryAsync(string companyId);
}
