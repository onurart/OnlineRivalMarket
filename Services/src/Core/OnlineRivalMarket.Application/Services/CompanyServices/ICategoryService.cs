using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.Queries.GetAllCategory;
using OnlineRivalMarket.Domain.CompanyEntities;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
        Task<PaginationResult<Category>> GetAllCategoryAsync(GetAllCategoryQuery request);
    }
}
