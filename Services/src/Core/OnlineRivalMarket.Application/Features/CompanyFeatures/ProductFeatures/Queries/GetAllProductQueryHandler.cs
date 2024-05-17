﻿using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Application.Services.CompanyServices;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries
{
    public sealed class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, GetAllProductQueryResponse>
    {
        private readonly IProductService _service;

        public GetAllProductQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return new(await _service.GetAllAsync(request));
        }

    }
}
