namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductCommandResponse>
{
    private readonly IProductService _productService;
    private readonly ILogService _logService;
    private readonly IApiService _apiService;
    public CreateProductCommandHandler(IProductService productService, ILogService logService, IApiService apiService)
    {
        _productService = productService;
        _logService = logService;
        _apiService = apiService;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product newProduct = await _productService.CreateProductAsync(request, cancellationToken);
        string userId = _apiService.GetUserIdByToken();
        Logs log = new()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(Brand),
            Progress = "Create",
            UserId = userId,
            Data = JsonConvert.SerializeObject(newProduct)
        };
        await _logService.AddAsync(log, request.CompanyId);
        return new CreateProductCommandResponse();
    }
}