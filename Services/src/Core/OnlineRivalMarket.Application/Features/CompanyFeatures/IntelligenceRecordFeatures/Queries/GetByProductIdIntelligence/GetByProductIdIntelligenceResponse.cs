﻿using OnlineRivalMarket.Domain.Dtos.IntelligenceDto;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetByProductIdIntelligence;
public sealed record GetByProductIdIntelligenceResponse(IList<IntelligenceByIdDto> Data);

