namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetSelectListAsync;
    public sealed class GetSelectListAsyncQueryHandle : IQueryHandler<GetSelectListAsyncQuery, GetSelectListAsyncQueryResponse>
    {
        private readonly IProductService _productService;
        public GetSelectListAsyncQueryHandle(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<GetSelectListAsyncQueryResponse> Handle(GetSelectListAsyncQuery request, CancellationToken cancellationToken)
        {
            return new(await _productService.GetSelectListAsync(request.CompanyId));
        }
    }
