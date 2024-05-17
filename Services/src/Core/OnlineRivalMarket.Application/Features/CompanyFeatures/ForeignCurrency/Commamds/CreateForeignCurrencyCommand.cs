﻿using OnlineRivalMarket.Application.Messaging;

namespace OnlineRivalMarket.Application.Features.CompanyFeatures.ForeignCurrency.Commamds;
public sealed record CreateForeignCurrencyCommand(string CurrencyName,string CompanyId):ICommand<CreateForeignCurrencyCommandResponse>;
