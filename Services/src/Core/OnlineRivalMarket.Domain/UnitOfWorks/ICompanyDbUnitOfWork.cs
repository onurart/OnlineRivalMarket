namespace OnlineRivalMarket.Domain.UnitOfWorks;
public interface ICompanyDbUnitOfWork : IUnitOfWork
{ void SetDbContextInstance(DbContext context); }
