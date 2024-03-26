﻿using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetAllIntelligenceRecord;
public sealed record GetAllIntelligenceRecordQuery(string CompanyId) : IQuery<GetAllIntelligenceRecordQueryResponse>;