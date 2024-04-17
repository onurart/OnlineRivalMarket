using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Queries.GetAllVehicleType
{
    public sealed class GetAllVehicleTypeQueryHandler : IQueryHandler<GetAllVehicleTypeQuery, GetAllVehicleTypeQueryResponse>
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public GetAllVehicleTypeQueryHandler(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public async Task<GetAllVehicleTypeQueryResponse> Handle(GetAllVehicleTypeQuery request, CancellationToken cancellationToken)
        {
            return new(await _vehicleTypeService.GetAllVehicleTypeAsync(request.CompanyId));
        }
    }
}
