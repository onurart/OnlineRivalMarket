using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
        Task<IList<Category>> GetAllCategoryAsync(string companyId);
    }
}
