using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
using OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Commands.CreateIntelligenceRecord;
using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IIntelligenceRecordService
    {
        Task<IntelligenceRecord> CreateIntelligenceRecordAsync(CreateIntelligenceRecordCommand requset, CancellationToken cancellationToken);
        Task<IList<IntelligenceRecord>> GetAllIntelligenceRecordAsync(string companyId);
        Task<IList<IntelligenceRecordDto>> GetAllDtoAsync(string companyId);
       
        
        
        
        Task<IList<IntelligenceRecordDto>> HomeGetTopIntelligenceRecordAsync(string companyId);
    }
}
