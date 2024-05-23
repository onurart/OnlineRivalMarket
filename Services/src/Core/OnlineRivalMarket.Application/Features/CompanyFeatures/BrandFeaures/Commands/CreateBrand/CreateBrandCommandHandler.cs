namespace OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;
public sealed class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand, CreateBrandCOmmandResponse>
{
    private readonly IBrandService _brandService;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;
    public CreateBrandCommandHandler(IBrandService brandService, IApiService apiService, ILogService logService)
    {
        _brandService = brandService;
        _apiService = apiService;
        _logService = logService;
    }
    public async Task<CreateBrandCOmmandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        Brand createBrand = await _brandService.CreateBrandAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Logs logs = new Logs()
        { Id = Guid.NewGuid().ToString(), TableName = nameof(Brand), Progress = "Create", UserId = userId, Data = JsonConvert.SerializeObject(createBrand) };
        await _logService.AddAsync(logs, request.CompanyId);
        return new();
    }
}
