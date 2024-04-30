﻿using OnlineRivalMarket.Application.Messaging;
namespace OnlineRivalMarket.Application.Features.CompanyFeatures.IntelligenceRecordFeatures.Queries.GetByIdIntelligenceRecord;
public sealed record GetByIdIntelligenceRecordQuery(string id, string CompanyId) : IQuery<GetByIdIntelligenceRecordQueryResponse>;
