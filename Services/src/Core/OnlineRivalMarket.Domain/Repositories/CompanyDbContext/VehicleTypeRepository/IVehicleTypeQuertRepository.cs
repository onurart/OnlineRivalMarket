﻿using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineRivalMarket.Domain.Repositories.CompanyDbContext.VehicleTypeRepository
{
    public interface IVehicleTypeQuertRepository : ICompanyDbQueryRepository<VehicleType>
    {
    }
}
