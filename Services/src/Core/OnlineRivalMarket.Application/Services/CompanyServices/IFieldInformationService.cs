using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
using OnlineRivalMarket.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface  IFieldInformationService
    {
        Task<FieldInformation> CreateFieldInformationAsync(CreateFieldInformationCommand requset, CancellationToken cancellationToken);
        Task<IList<FieldInformation>> GetAllFieldInformationAsync(string companyId);
    }
}
