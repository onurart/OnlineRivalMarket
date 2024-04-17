using OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Commands.CreateVehicleGroup;
using OnlineRivalMarket.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Services.CompanyServices
{
    public interface IVehicleGroupService
    {
        Task<VehicleGroup> CreateVehicleGroupAsync(CreateVehicleGroupCommand request, CancellationToken cancellationToken);
        Task<IList<VehicleGroup>> GetAllVehicleGroupAsync(string CompanyId);
    }
}
