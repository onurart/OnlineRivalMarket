﻿using OnlineRivalMarket.Domain.Dtos.ForeignCurrency;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Queries.GetAllForeignCurrency.GetAllForeignCurrencyDtoAsync;
public sealed record  GetAllForeignCurrencyDtoQueryResponse(IList<ForeignCurrencyDto> Data);