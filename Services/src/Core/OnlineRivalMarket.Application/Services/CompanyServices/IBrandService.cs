
namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IBrandService
    {
        Task<Brand> CreateBrandAsync(CreateBrandCommand requset, CancellationToken cancellationToken);
        Task<IList<Brand>> GetAllBrandsAsync(string companyId);
    }
}
