using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct
{
    public sealed record CreateProductCommandResponse(string Message = "Ürün Kaydı Başarıyla Tamamlandı");
}
