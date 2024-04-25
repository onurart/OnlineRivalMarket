﻿using OnlineRivalMarket.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CampaignFeaures.Queries;

public sealed record GetAllCampaignQuery(string CompanyId, int PageNumber = 0, int PageSize = 10) : IQuery<GetAllCampaignQueryResponse>;
