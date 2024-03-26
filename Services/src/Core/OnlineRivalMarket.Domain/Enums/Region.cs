using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Enums
{
    public enum Region
    {
        [Display(Name = "Akdeniz Bölgesi")]
        AkdenizBolgesi = 0,

        [Display(Name = "Doğu Anadolu Bölgesi.")]
        DoguAnadoluBolgesi = 10,

        [Display(Name = "Ege Bölgesi")]
        EgeBolgesi = 20,

        [Display(Name = "Güneydoğu Anadolu Bölgesi")]
        GuneydoguAnadoluBolgesi = 30,

        [Display(Name = "İç Anadolu Bölgesi.")]
        IcAnadoluBolgesi = 40,

        [Display(Name = "Karadeniz Bölgesi.")]
        KaradenizBolgesi = 50,
        [Display(Name = "Marmara Bölgesi.")]
        MarmaraBolgesi = 60


    }
}
