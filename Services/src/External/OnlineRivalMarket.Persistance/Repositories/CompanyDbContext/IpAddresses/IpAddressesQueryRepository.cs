using OnlineRivalMarket.Domain.Repositories.CompanyDbContext.IpAddressRepositories;

namespace OnlineRivalMarket.Persistance.Repositories.CompanyDbContext.IpAddresses;
public class IpAddressesQueryRepository : CompanyDbQueryRepository<ClientIpAddresses>, IIpAddressQueryRepository { }
