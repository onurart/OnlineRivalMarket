using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Queries;
public sealed class GetAllVehicleGroupQueryHandler : IQueryHandler<GetAllVehicleGroupQuery, GetAllVehicleGroupQueryResponse>
{
    private readonly IVehicleGroupService _vehicleGroupService;

    public GetAllVehicleGroupQueryHandler(IVehicleGroupService vehicleGroupService)
    {
        _vehicleGroupService = vehicleGroupService;
    }

    public async Task<GetAllVehicleGroupQueryResponse> Handle(GetAllVehicleGroupQuery request, CancellationToken cancellationToken)
    {
        return new(await _vehicleGroupService.GetAllVehicleGroupAsync(request.CompanyId));
    }
}
