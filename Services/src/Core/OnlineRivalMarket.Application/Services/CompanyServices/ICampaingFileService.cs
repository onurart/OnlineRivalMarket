using OnlineRivalMarket.Domain.CompanyEntities;
namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICampaingFileService
    {
        Task<CampaingImagesFile> CreateAsync(CampaingImagesFile imagesFile, string companyid, CancellationToken cancellationToken);
        IQueryable<CampaingImagesFile> GetAll(string companyId);
        Task UpdateAsync(CampaingImagesFile ticketFile);
        Task RemoveByIdAsync(string id);

    }
}
