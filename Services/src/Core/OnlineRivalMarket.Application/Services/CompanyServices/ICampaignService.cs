using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries.GetAllDtoAsync;
using OnlineRivalMarket.Domain.Dtos.Campaing;
using OnlineRivalMarket.Domain.Dtos.Campaing.HomeTopDto;
namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICampaignService
    {
        Task<Campaigns> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken);
        Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId);
        Task<IList<HomeTopCampaignDto>> GetAllCampaingAsync(string companyId);
        Task<PaginationResult<HomeTopCampaignDto>> GetAllDtoAsync(GetAllDtoAsyncQuery request);
        Task<IList<CampaignsDetailDto>> GetListByIdDtoAsync(string id,string companyId);
        Task UpdateAsync(Campaigns product, string companyId);
        Task<IList<CampaignsDetailDto>> GetAllDtoFilterAsync(string companyId,List<string> competitorIds,List<string> productIds,List<string> brandIds,List<string> categoryIds,DateTime startDate,DateTime endDate,DateTime CreateDate,DateTime EndCreateDate,string keyword);
        Task<IList<GetByCampaingProductIntelligenceRecord>> GetByCampaingProductIntelligenceRecordsAsync(string id, string companyId);


    }
}
