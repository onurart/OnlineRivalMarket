namespace OnlineRivalMarket.Application.Services.CompanyServices;
public interface ICampaignService
{
    Task<IList<GetAllDtoFilterDto>> GetAllDtoFilterAsync(string companyId, List<string> competitorIds, List<string> productIds, List<string> brandIds, List<string> categoryIds, DateTime startDate, DateTime endDate, DateTime CreateDate, DateTime EndCreateDate, string keyword);
    Task<IList<GetByCampaingProductIntelligenceRecord>> GetByCampaingProductIntelligenceRecordsAsync(string id, string companyId);
    Task<Campaigns> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<HomeTopCampaignDto>> GetAllDtoAsync(GetAllDtoAsyncQuery request);
    Task<IList<CampaignsDetailDto>> GetListByIdDtoAsync(string id, string companyId);
    Task<IList<HomeTopCampaignDto>> HomeTopGetAllDtoAsync(string companyId);
    Task<IList<GetAllCampaingDto>> GetAllCampaingAsync(string companyId);
    Task UpdateAsync(Campaigns product, string companyId);


}
