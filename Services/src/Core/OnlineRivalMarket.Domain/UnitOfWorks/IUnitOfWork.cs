﻿namespace OnlineRivalMarket.Domain.UnitOfWorks;
public interface IUnitOfWork { Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); }
