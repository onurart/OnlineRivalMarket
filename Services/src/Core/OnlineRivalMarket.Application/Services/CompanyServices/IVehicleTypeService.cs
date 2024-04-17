using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Commands.CreateVehicleType;
using OnlineRivalMarket.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IVehicleTypeService
    {
        Task<VehicleType> CreateVehicleTypeAsync(CreateVehicleTypeCommand requst, CancellationToken cancellationToken);
        Task<IList<VehicleType>> GetAllVehicleTypeAsync(string companyId);

    }
}
