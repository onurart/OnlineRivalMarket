namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllProduct;
public sealed class GetAllProductCommandHandler : IQueryHandler<GetAllProductCommandQuery, GetAllProductCommandResponse>
{
    private readonly IProductService _productService;
    public GetAllProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<GetAllProductCommandResponse> Handle(GetAllProductCommandQuery request, CancellationToken cancellationToken)
    {
        return new(await _productService.GetAllProduct(request.CompanyId));
    }
}
