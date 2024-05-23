namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleGroupFeaures.Commands.CreateVehicleGroup;
public sealed class CreateVehicleGroupCommandHandler : ICommandHandler<CreateVehicleGroupCommand, CreateVehicleGroupCommandResponse>
{
    private readonly IVehicleGroupService _vehicleGroupService;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;
    public CreateVehicleGroupCommandHandler(IVehicleGroupService vehicleGroupService, IApiService apiService, ILogService logService)
    {
        _vehicleGroupService = vehicleGroupService;
        _apiService = apiService;
        _logService = logService;
    }
    public async Task<CreateVehicleGroupCommandResponse> Handle(CreateVehicleGroupCommand request, CancellationToken cancellationToken)
    {
        VehicleGroup vehicleGroup = await _vehicleGroupService.CreateVehicleGroupAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Logs log = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(VehicleGroup),
            Progress = "Create",
            Data = JsonConvert.SerializeObject(vehicleGroup)
        };
        await _logService.AddAsync(log, request.CompanyId);
        return new();
    }
}