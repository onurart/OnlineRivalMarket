using OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Rules;
using OnlineRivalMarket.Application.Services.LogService;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.BrandFeaures.Commands.CreateBrand;

public sealed class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand, CreateBrandCOmmandResponse>
{
    private readonly IBrandService _brandService;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;
    private readonly ILogDataFactory<Brand> _logFactory;
    private readonly BrandBusinessRules _brandBusinessRules;

    public CreateBrandCommandHandler(IBrandService brandService, IApiService apiService, ILogService logService,
        BrandBusinessRules brandBusinessRules, ILogDataFactory<Brand> logFactory = null)
    {
        _brandService = brandService;
        _apiService = apiService;
        _logService = logService;
        _brandBusinessRules = brandBusinessRules;
        _logFactory = logFactory;
    }

    public async Task<CreateBrandCOmmandResponse> Handle(CreateBrandCommand request,
        CancellationToken cancellationToken)
    {
        await _brandBusinessRules.IsbrandUnique(request.Name);
        Brand createBrand = await _brandService.CreateBrandAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        var logData = _logFactory.CreateLogData(createBrand, userId, nameof(Brand), "Create");


        await _logService.AddAsync(logData, request.CompanyId);
        return new();
    }
}