﻿namespace OnlineRivalMarket.Domain.Repositories.GenericRepositories;
public interface IRepository<T> where T : Entity { DbSet<T> Entity { get; set; } }