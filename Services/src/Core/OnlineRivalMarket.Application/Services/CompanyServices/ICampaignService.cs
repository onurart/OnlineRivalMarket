using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.HomeTopDto;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICampaignService
    {
        Task<Campaigns> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken);
        Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId);
        Task<IList<HomeTopCampaignDto>> GetAllCampaingAsync(string companyId);
        Task<PaginationResult<HomeTopCampaignDto>> GetAllDtoAsync(GetAllDtoAsyncQuery request);
        //Task<IList<Campaigns>> GetCampaignsAsync(string companyId);
        Task<IList<CampaignsDetailDto>> GetListByIdDtoAsync(string id,string companyId);
        Task UpdateAsync(Campaigns product, string companyId);
        //Task<IList<CampaignsDetailDto>> GetAllDtoFilterAsync(string companyId, List<string> competitorId, List<string> brandId, List<string> categoryId, DateTime startdate, DateTime enddate, string keyword);
        Task<IList<CampaignsDetailDto>> GetAllDtoFilterAsync(
        string companyId,
        List<string> competitorIds,
        List<string> productIds,
        List<string> brandIds,
        List<string> categoryIds,
        DateTime startDate,
        DateTime endDate,
        DateTime CreateDate,
        DateTime EndCreateDate,
        string keyword);

    }
}
