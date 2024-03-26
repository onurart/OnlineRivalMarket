using Newtonsoft.Json;
using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services;
using OnlineRivalMarket.Application.Services.CompanyServices;
using OnlineRivalMarket.Domain.CompanyEntities;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryService _service;
    private readonly IApiService _apiService;
    private readonly ILogService _logService;

    public CreateCategoryCommandHandler(ICategoryService service, IApiService apiService, ILogService logService)
    {
        _service = service;
        _apiService = apiService;
        _logService = logService;
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