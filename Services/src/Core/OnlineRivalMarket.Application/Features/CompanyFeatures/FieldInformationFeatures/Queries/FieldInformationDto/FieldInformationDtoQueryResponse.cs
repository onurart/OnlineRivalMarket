﻿using OnlineRivalMarket.Domain.Dtos.FieldInformationDtos;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationDto;
public sealed record  FieldInformationDtoQueryResponse(IList<FieldInformationsesDto> Data);
