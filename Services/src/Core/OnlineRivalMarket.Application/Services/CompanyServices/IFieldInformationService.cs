using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Commands;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationDto;
using OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationHome;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos.FieldInformationDtos;
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
        Task<IList<FieldInformationsesDto>> GetAllFieldInformationDtoAsync(FieldInformationDtoQuery companyId);
        Task<IList<FieldInformationsesDto>> GetAllFieldInformationHomeAsync(FieldInformationHomeQuery companyId);
        Task<IList<FieldInformationsesDto>> GetAllFieldInformationByIdAsync(string id,string companyId);
    }
}
