﻿using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetByProductIdIntelligence;
public sealed record GetByProductIdIntelligenceQuery(string id,string CompanyId) : IQuery<GetByProductIdIntelligenceResponse>;
