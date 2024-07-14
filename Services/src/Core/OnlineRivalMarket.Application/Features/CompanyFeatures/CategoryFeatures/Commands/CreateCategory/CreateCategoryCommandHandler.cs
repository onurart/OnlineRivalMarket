using OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Rule;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryService _service;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;
    private readonly CategoryBusinessRules _categoryBusinessRules;

	public CreateCategoryCommandHandler(ICategoryService service, IApiService apiService, ILogService logService, CategoryBusinessRules categoryBusinessRules = null)
	{
		_service = service;
		_apiService = apiService;
		_logService = logService;
		_categoryBusinessRules = categoryBusinessRules;
	}

	public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category createBrand = await _service.CreateCategoryAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Logs log = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(Brand),
            Progress = "Create",
            UserId = userId,
            Data = JsonConvert.SerializeObject(createBrand)
        };
        await _logService.AddAsync(log, request.CompanyId);
        return new();
    }
}