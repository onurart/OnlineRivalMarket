﻿using OnlineRivalMarket.Domain.CompanyEntities;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries;
public sealed record GetAllFieldInformationQueryReponse(IList<FieldInformation> Data);
