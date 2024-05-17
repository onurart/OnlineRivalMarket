﻿using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.CompanyDbContext;
namespace OnlineRivalMarket.Domain.Repositories.CompanyDbContext.ImagesFileRepositories;
public interface IImagesFileCommandRepository : ICompanyDbCommandRepository<ImagesFile>
{
}
