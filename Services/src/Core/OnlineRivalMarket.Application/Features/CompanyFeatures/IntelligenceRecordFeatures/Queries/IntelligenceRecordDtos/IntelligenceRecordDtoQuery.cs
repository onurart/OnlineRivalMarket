﻿using OnlineRivalMarket.Application.Messaging;
using OnlineRivalMarket.Domain.Dtos;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.IntelligenceRecordDtos;
public sealed record IntelligenceRecordDtoQuery(string CompanyId) : IQuery<IntelligenceRecordDtoQueryResponse>;
