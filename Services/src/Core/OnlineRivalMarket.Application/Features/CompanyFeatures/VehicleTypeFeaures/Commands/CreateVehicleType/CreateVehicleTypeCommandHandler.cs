namespace OnlineRivalMarket.Application.Features.CompanyFeatures.VehicleTypeFeaures.Commands.CreateVehicleType;
public class CreateVehicleTypeCommandHandler : ICommandHandler<CreateVehicleTypeCommand, CreateVehicleTypeCommandResponse>
{
    private readonly IVehicleTypeService _vehicleTypeService;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;
    public CreateVehicleTypeCommandHandler(IVehicleTypeService vehicleTypeService, IApiService apiService, ILogService logService)
    {
        _vehicleTypeService = vehicleTypeService;
        _apiService = apiService;
        _logService = logService;
    }
    public async Task<CreateVehicleTypeCommandResponse> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
    {
        VehicleType vehicleType = await _vehicleTypeService.CreateVehicleTypeAsync(request,cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Logs logs = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(VehicleType),
            Progress = "Create",
            UserId = userId,
            Data = JsonConvert.SerializeObject(vehicleType)
        };
        await _logService.AddAsync(logs, request.companyId);
        return new();
    }
}
