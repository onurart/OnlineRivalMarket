﻿using EntityFrameworkCorePagination.Nuget.Pagination;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.GetAllDtoFilterField;
public sealed record FieldInformationseResponse(PaginationResult<FieldInformationsesDto> Data);