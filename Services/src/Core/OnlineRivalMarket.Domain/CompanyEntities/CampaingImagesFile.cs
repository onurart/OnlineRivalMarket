using OnlineRivalMarket.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineRivalMarket.Domain.CompanyEntities
{
    public class CampaingImagesFile : Entity
    {
        public CampaingImagesFile()
        {
        }
        public CampaingImagesFile(string id,string campaingId,string campaingFİleUrls) :base(id)
        {
            CampaignsId=campaingId;
            CampaingFİleUrls= campaingFİleUrls;
        }

        [ForeignKey(nameof(Campaigns))]
        public string CampaignsId { get; set; }
        public string CampaingFİleUrls { get; set; }
    }

}
