using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using OnlineRivalMarket.Domain.Dtos.HomeTopDto;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICampaignService
    {
        Task<Campaigns> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken);
        Task<PaginationResult<Campaigns>> GetAllAsync(GetAllCampaignQuery requst);
        Task UpdateAsync(Campaigns product, string companyId);
        Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId);
        Task<IList<CampaignsDetailDto>> GetListByIdDtoAsync(string id,string companyId);
    }
}
