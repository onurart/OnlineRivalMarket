using OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Commands.CreateCampaign;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.HomeTopDto;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface ICampaignService
    {
        Task<Campaigns> CreateCampaignAsync(CreateCampaignCommand request, CancellationToken cancellationToken);
        Task<IList<Campaigns>> GetAllAsync(string companyId);
        Task UpdateAsync(Campaigns product, string companyId);
        Task<IList<Campaigns>> HomeTopGetAllDtoAsync(string companyId);

    }
}
