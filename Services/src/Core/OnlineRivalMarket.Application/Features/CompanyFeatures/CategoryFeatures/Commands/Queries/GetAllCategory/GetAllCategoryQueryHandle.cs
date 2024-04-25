using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.Queries.GetAllCategory
{
    public sealed class GetAllCategoryQueryHandle : IQueryHandler<GetAllCategoryQuery, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryService _categoryService;
        public GetAllCategoryQueryHandle(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return new(await _categoryService.GetAllCategoryAsync(request));
        }
    }
}
