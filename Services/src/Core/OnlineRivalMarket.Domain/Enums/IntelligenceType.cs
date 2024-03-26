using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Domain.Enums
{
    public enum IntelligenceType
    {
        [Display(Name = "Diğer")]
        Dıger = 0,
        [Display(Name = "Kampanya")]
        Kampanya = 10,
        [Display(Name = "Fiyat İskontosu")]
        Fiyatİskontosu = 20,
        [Display(Name = "Ödeme Şekli")]
        odemeSekli = 30,
    }
}
