﻿using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Domain.Repositories.CompanyDbContext.CampaingImagesFileRepositories;
public interface ICampaingFileCommandRepository  : ICompanyDbCommandRepository<CampaingImagesFile>
{
}
