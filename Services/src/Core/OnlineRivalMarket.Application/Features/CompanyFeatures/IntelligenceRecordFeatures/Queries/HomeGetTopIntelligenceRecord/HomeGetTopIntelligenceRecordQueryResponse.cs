﻿using OnlineRivalMarket.Domain.Dtos;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.HomeGetTopIntelligenceRecord;
public sealed record HomeGetTopIntelligenceRecordQueryResponse(IList<IntelligenceRecordDto> Data);


