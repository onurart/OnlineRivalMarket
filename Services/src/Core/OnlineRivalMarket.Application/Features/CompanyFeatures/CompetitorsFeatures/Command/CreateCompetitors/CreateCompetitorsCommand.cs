﻿using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.CompetitorsFeatures.Command.CreateCompetitors;

public sealed record  CreateCompetitorsCommand(string Name, string companyId):ICommand<CreateCompetitorsCommandResponse>;
