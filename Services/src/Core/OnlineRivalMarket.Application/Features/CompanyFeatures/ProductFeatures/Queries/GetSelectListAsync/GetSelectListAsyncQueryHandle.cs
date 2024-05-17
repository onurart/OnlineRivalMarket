using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetSelectListAsync
{
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
}
