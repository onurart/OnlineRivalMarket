﻿using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.FieldInformationFeatures.Queries.FieldInformationHome;
public sealed record FieldInformationHomeQuery(string CompandyId) : IQuery<FieldInformationHomeQueryResponse>;
