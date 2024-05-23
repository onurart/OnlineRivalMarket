namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Commamds;
public sealed class CreateForeignCurrencyCommandHandler : ICommandHandler<CreateForeignCurrencyCommand, CreateForeignCurrencyCommandResponse>
{
    private readonly IForeignCurrencyService _service;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;
    public CreateForeignCurrencyCommandHandler(IForeignCurrencyService service, ILogService logService = null, IApiService apiService = null)
    {
        _service = service;
        _logService = logService;
        _apiService = apiService;
    }

    public async Task<CreateForeignCurrencyCommandResponse> Handle(CreateForeignCurrencyCommand request, CancellationToken cancellationToken)
    {
        OnlineRivalMarket.Domain.CompanyEntities.ForeignCurrency foreignCurrency = await _service.CreateForeignCurrencyAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Logs log = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(ForeignCurrency),
            Progress = "Create",
            UserId = userId,
            Data = JsonConvert.SerializeObject(foreignCurrency)
        };
        await _logService.AddAsync(log,request.CompanyId);
        return new();
    }
}
