﻿namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ProductFeatures.Queries;
public sealed record GetAllProductQueryResponse(PaginationResult<ProductDto> Data);