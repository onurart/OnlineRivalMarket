using OnlineRivalMarket.Domain.CompanyEntities;
using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.IpAddressRepositories;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.IpAddresses;
public sealed class IpAddressesCommandRepository : CompanyDbCommandRepository<ClientIpAddresses>, IIpAddressesCommandRepository { }
