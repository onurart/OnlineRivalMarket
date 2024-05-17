using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Dtos.FieldInformationDtos
{
    public  class FieldInformationsesDto
    {
        public string Id { get; set; }
        public string CompetitorId { get; set; }
        public string CompetitorName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<string> ImageFiles { get; set; }


    }
}
