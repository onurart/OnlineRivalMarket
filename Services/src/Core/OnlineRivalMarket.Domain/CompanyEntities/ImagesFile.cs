using OnlineRivalMarket.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRivalMarket.Domain.CompanyEntities
{
    public class ImagesFile : Entity
    {
        public ImagesFile()
        {

        }

        public ImagesFile(string id, string intelligenceRecordid, string fileUrls) : base(id)
        {
            IntelligenceRecordId = intelligenceRecordid;
            FileUrls = fileUrls;
        }
        [ForeignKey(nameof(IntelligenceRecord))]
        public string IntelligenceRecordId { get; set; }
        public string FileUrls { get; set; }
    }
}
