using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.AppEntities
{
    public class NlogDBLogFE
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [StringLength(10)]
        public string Level { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Exception { get; set; }
        [StringLength(255)]
        public string Logger { get; set; }
        [StringLength(255)]
        public string Url { get; set; }
    }
}
